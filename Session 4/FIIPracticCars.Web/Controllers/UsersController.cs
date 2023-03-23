using FIIPracticCars.Repositories;
using FIIPracticCars.Repositories.Dtos;
using FIIPracticCars.Web.Models;
using FIIPracticCars.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FIIPracticCars.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICarsUnitOfWork _carsUnitOfWork;

        public UsersController(IUserRepository userRepository, ICarsUnitOfWork carsUnitOfWork)
        {
            _userRepository = userRepository;
            _carsUnitOfWork = carsUnitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userDtos = _userRepository.GetAll();

            var userViewModels = userDtos.Select(u => new UserViewModel
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
            });

            return View(userViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateUserViewModel createUserViewModel)
        {
            if (createUserViewModel == null)
            {
                return RedirectToAction("Error", new { message = "CreateUserViewModel is null!" });
            }

            if (!ModelState.IsValid)
            {
                return View(createUserViewModel);
            }

            var userDto = new UserDto
            {
                FirstName = createUserViewModel.FirstName,
                LastName = createUserViewModel.LastName,
                Email = createUserViewModel.Email,
                PasswordHash = createUserViewModel.Password
            };

            _userRepository.CreateUser(userDto);
            _carsUnitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Error", new { message = "User Id is negative!" });
            }

            var userDto = _userRepository.GetUser(id);
            if (userDto == null)
            {
                return RedirectToAction("Error", new { message = "User not found!" });
            }

            var updateUserViewModel = new UpdateUserViewModel
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
            };

            return View(updateUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] UpdateUserViewModel updateUserViewModel)
        {
            if (updateUserViewModel == null)
            {
                return RedirectToAction("Error", new { message = "UpdateUserViewModel is null!" });
            }

            if (!ModelState.IsValid)
            {
                return View(updateUserViewModel);
            }

            var userDto = _userRepository.GetUser(updateUserViewModel.Id);
            if (userDto == null)
            {
                return RedirectToAction("Error", new { message = "User not found!" });
            }

            userDto.FirstName = updateUserViewModel.FirstName;
            userDto.LastName = updateUserViewModel.LastName;

            _userRepository.UpdateUser(userDto);
            _carsUnitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Error", new { message = "User Id is negative!" });
            }

            var userDto = _userRepository.GetUser(id);
            if (userDto == null)
            {
                return RedirectToAction("Error", new { message = "User not found!" });
            }

            var userViewModel = new UserViewModel
            {
                Id = id,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
            };

            return View(userViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Error", new { message = "User Id is negative!" });
            }

            _userRepository.DeleteUser(id);
            _carsUnitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Error", new { message = "User Id is negative!" });
            }

            var userDto = _userRepository.GetUser(id);
            if (userDto == null)
            {
                return RedirectToAction("Error", new { message = "User not found!" });
            }

            var userViewModel = new UserViewModel
            {
                Id = id,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
            };

            return View(userViewModel);
        }

        public IActionResult Error(string message)
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = message
            });
        }
    }
}
