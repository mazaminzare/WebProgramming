using EFCore.Application.ViewModels;
using EFCore.Data.Context;
using EFCore.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Mvc.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _db;
        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //var books = _db.Books.ToList();
            var books = _db.Books.Include(b => b.Category).Include(b => b.BookAuthors).ThenInclude(b => b.Author).Include(b => b.Publisher).Include(b => b.BookDetail).ToList();


            //var books = _db.Books.Include(b => b.Category).Include(b => b.Publisher).Include(b => b.BookDetail)
            //    .Include(b=>b.BookAuthors)
            //    .ThenInclude(a=>a.Author)
            //    .ToList();

            //for (int i = 0; i < books.Count; i++)
            //{
            //    books[i].Publisher = _db.Publishers.Find(books[i].Publisher_Id);
            //    books[i].Category = _db.Categories.Find(books[i].Category_Id);
            //}
            //foreach (var book in books)
            //{
            //    _db.Entry(book).Reference(u=>u.Publisher).Load(); // explicit load
            //    _db.Entry(book).Reference(u=>u.Category).Load();
            //}


            //foreach (var book in books)
            //{
            //    _db.Entry(book).Collection(b => b.BookAuthors).Load();

            //    foreach (var bookBookAuthor in book.BookAuthors)
            //    {
            //        _db.Entry(bookBookAuthor).Reference(a => a.Author).Load();

            //    }
            //}


            // View
            //var viewList = _db.bookDetailFromViews.ToList();
            //var viewLis2 = _db.bookDetailFromViews.FirstOrDefault();
            //var viewList3 = _db.bookDetailFromViews.Where(u => u.Price > 3).ToList();

            //var booRaw = _db.Books.FromSqlRaw("Select * from Books").ToList();
            var id = 2;
            var raw1 = _db.Books.FromSqlInterpolated($"Select * From Books where BookId={id}").ToList();
            var sp = _db.Books.FromSqlInterpolated($"EXEC dbo.getAllBookDetails {id}").ToList();



            var bookFilter = _db.Books.Include(b=>b.BookAuthors.Where(a=>a.AuthorId==1)).ToList();
            var bookFilter2 = _db.Books.Include(b=>b.BookAuthors.OrderByDescending(a=>a.AuthorId==1)).Take(2).ToList();

            return View(books);
        }

        public IActionResult Upsert(int? id)
        {

            BookViewModel book = new BookViewModel();
            book.PublisherList = _db.Publishers.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.PublisherId.ToString()
            });
            book.CategoryList = _db.Categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.CategoryId.ToString()
            });

            if (id == null)
            {
                book.Book = new Book();
                return View(book);
            }

            book.Book = _db.Books.Find(id);
            if (book.Book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Upsert(BookViewModel crBK)
        {
            if (true)
            {
                if (crBK.Book.BookId == 0)
                {
                    crBK.Book.BookDetailId = 2;
                    _db.Add(crBK.Book);
                }
                else
                {
                    _db.Update(crBK.Book);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crBK);
        }

        public IActionResult Delete(int id)
        {

            var book = _db.Books.Find(id);
            _db.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //Lazy Query
        public void PlayGround()
        {
            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;

            // video 28
            //IEnumerable<Book> BookList = _db.Books.Include(b => b.Category).Include(b => b.Publisher).Include(b => b.BookDetail); // run on program side
            //var filter = BookList.Where(b => b.Price==3).ToList(); 

            //IQueryable<Book> bookListQ = _db.Books.Include(b => b.Category).Include(b => b.Publisher).Include(b => b.BookDetail); // run on sqlserver side
            //var filterQ = bookListQ.Where(b => b.Price > 3).ToList();

            // video 29
            //    var bookTemp1 = _db.Books.Include(b => b.BookDetail)
            //        .FirstOrDefault(b => b.BookId == 2);
            //    bookTemp1.BookDetail.NumberOfPages = 123;
            //    _db.Books.Update(bookTemp1);// taghirat ra donbal nemikonad va kol jadval va rabete ra update mikonad
            //    _db.SaveChanges();

            //    var bookTemp2 = _db.Books.Include(b => b.BookDetail)
            //        .FirstOrDefault(b => b.BookId == 2);
            //    bookTemp2.BookDetail.Weight = 800;
            //    _db.Books.Attach(bookTemp2);  // faghat update ra roye jadvali ke dakhelesh taghir daadim update mishe
            //    _db.SaveChanges(); // attach taghirat ra donabal mikonad va chizi ke taghhir karde ra update mikonad
            //

            //// video 30
            var category = _db.Categories.FirstOrDefault();
            category.Name = "Manual Change";
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();


            var bookTemp2 = _db.Books.Include(b => b.BookDetail)
                .FirstOrDefault(b => b.BookId == 2);
            bookTemp2.BookDetail.Weight = 800;
            _db.Entry(bookTemp2).State = EntityState.Modified; // faghat update ra roye jadvali ke dakhelesh taghir daadim update mishe
            _db.SaveChanges(); // attach taghirat ra donabal mikonad va chizi ke taghhir karde ra update mikonad




        }


        public IActionResult ManageAuthors(int id)
        {
            BookAuthorViewModel bookAuthor = new BookAuthorViewModel()
            {
                BookAuthors = _db.BookAuthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .Where(b => b.BookId == id).ToList(),
                BookAuthor = new BookAuthor()
                {
                    BookId = id
                },
                Book = _db.Books.Find(id)

            };

            List<int> listofAuthors = bookAuthor.BookAuthors.Select(u => u.AuthorId).ToList();
            var tempList = _db.Authors.Where(a => !listofAuthors.Contains(a.AuthorId)).ToList();
            bookAuthor.AuthorList = tempList.Select(i => new SelectListItem()
            {
                Value = i.AuthorId.ToString(),
                Text = i.FullName
            });


            return View(bookAuthor);

        }
        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorViewModel bookAuthorVm)
        {
            if (bookAuthorVm.BookAuthor.BookId != 0 && bookAuthorVm.BookAuthor.AuthorId != 0)
            {
                _db.BookAuthors.Add(bookAuthorVm.BookAuthor);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVm.BookAuthor.BookId });
        }


        public IActionResult RemoveAuthor(int id, BookAuthorViewModel bookAuthorViewModel)
        {
            int bookId = bookAuthorViewModel.Book.BookId;
            var bookAuthor = _db.BookAuthors.FirstOrDefault(b => b.AuthorId == id && b.BookId == bookId);
            _db.BookAuthors.Remove(bookAuthor);
            _db.SaveChanges();
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });

        }



    }
}
