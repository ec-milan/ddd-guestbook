using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly IRepository _repository;

        #endregion Fields


        #region Methods

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Index()
        {
            if (_repository.List<Guestbook>().Any() == false)
            {
                var newGuestbook = new Guestbook();

                newGuestbook.Entries.Add(new GuestbookEntry
                {
                    DateTimeCreated = DateTime.UtcNow.AddHours(-1),
                    EmailAddress = "test-1@test.com",
                    Message = "Hello!"
                });

                newGuestbook.Entries.Add(new GuestbookEntry
                {
                    DateTimeCreated = DateTime.UtcNow.AddHours(-2),
                    EmailAddress = "test-2@test.com",
                    Message = "Hi!"
                });

                newGuestbook.Entries.Add(new GuestbookEntry
                {
                    DateTimeCreated = DateTime.UtcNow.AddHours(-3),
                    EmailAddress = "test-3@test.com",
                    Message = "Olla!"
                });

                _repository.Add(newGuestbook);
            }

            var guestbook = _repository.GetById<Guestbook>(1, nameof(Guestbook.Entries));

            var homePageViewModel = new HomePageViewModel
            {
                GuestbookName = "My Guestbook",
                PreviousEntries = guestbook.Entries
            };

            return View(homePageViewModel);
        }

        [HttpPost]
        public IActionResult Index(HomePageViewModel homePageViewModel)
        {
            if (ModelState.IsValid)
            {
                var guestbook = _repository.GetById<Guestbook>(1, nameof(Guestbook.Entries));
                guestbook.Entries.Add(homePageViewModel.NewEntry);
                _repository.Update<Guestbook>(guestbook);

                return RedirectToAction();
            }

            return View(homePageViewModel);
        }

        #endregion Methods


        #region Constructors

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        #endregion Constructors
    }
}
