using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TabHolidayCore.Models;
using Microsoft.EntityFrameworkCore;

namespace TabHolidayCore.Controllers
{
    public class MealController : Controller
    {
        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();

        public MealController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Authorize]
        public string Index()
        {
            try
            {
                TabMeal[] TabMeals = _context.TabMeals.Include(s => s.FoodType).Include(a => a.RestaurantType).ToArray();
                returnObject.ChangedData = TabMeals;
                returnObject.isSuccess = true;
            }
            catch (Exception ex)
            {
                returnObject.isSuccess = false;
                returnObject.Message = returnObject.GetErrorMessage(ex);
            }

            return returnObject.GetResponse();
        }

        [HttpPost]
        [Authorize]
        public string Add([FromBody]TabMeal newTabMeal)
        {
            try
            {
                if (newTabMeal.TabMealId == 0)
                {

                    _context.TabMeals.Add(newTabMeal);
                }
                else
                {
                    _context.Entry<TabMeal>(newTabMeal).State = EntityState.Modified;

                }

                _context.SaveChanges();
                returnObject.ChangedData = newTabMeal;
                returnObject.isSuccess = true;
                returnObject.Message = returnObject.GetSaveMessage();
            }
            catch (Exception ex)
            {
                returnObject.isSuccess = false;
                returnObject.Message = returnObject.GetErrorMessage(ex);

            }
            return returnObject.GetResponse();
        }


        [HttpPost]
        [Authorize]
        public string GetTabMeals([FromBody]TabMeal meal)
        {
            try
            {
                var TabMealQuery = _context.TabMeals.AsQueryable();

            
                if (meal.Name != string.Empty && meal.Name != null)
                {
                    TabMealQuery = TabMealQuery.Where(d => d.Name.Contains(meal.Name));
                }


                if (meal.City != string.Empty && meal.City != null)
                {
                    TabMealQuery = TabMealQuery.Where(d => d.City.Contains(meal.City));
                }

                if (meal.RestaurantTypeId > 0)
                {
                    TabMealQuery = TabMealQuery.Where(d => d.RestaurantTypeId == meal.RestaurantTypeId);
                }


                returnObject.isSuccess = true;
                returnObject.ChangedData = TabMealQuery.Include(d => d.RestaurantType).ToArray();
            }
            catch (Exception ex)
            {

                returnObject.isSuccess = false;
                returnObject.Message = returnObject.GetErrorMessage(ex);
            }

            return returnObject.GetResponse();
        }
    }
}