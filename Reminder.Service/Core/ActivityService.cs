using Microsoft.EntityFrameworkCore;
using Reminder.Service.Data;
using Reminder.Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity = Reminder.Service.Models.Activity;

namespace Reminder.Service.Core
{
    public class ActivityService
    {
        private readonly AppDbContext _db;
        public ActivityService(AppDbContext db)
        {
            _db = db;
        }
        public List<ActivityDTO> GetAll()
        {
            var models = _db.Activities.Include(p => p.Category).ToList();
            var dtoList = new List<ActivityDTO>();
            foreach (var model in models)
            {
                var dto = new ActivityDTO()
                {
                    Id = model.Id,
                    CategoryId = model.CategoryId,
                    Name = model.Name,
                    Description = model.Description,
                    CategoryName = model.Category.Name,
                    Time = model.Time,
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public ActivityDTO GetEditViewModel(int id)
        {
            var model = _db.Activities.First(p => p.Id == id);
            var dto = new ActivityDTO()
            {
                Id = id,
                CategoryId = model.CategoryId,
                Name = model.Name,
                Description = model.Description,
            };
            dto.CategoryList = _db.Categories.ToList();
            return dto;
        }
        public ActivityDTO GetCreateViewModel()
        {
            var dto = new ActivityDTO();
            dto.CategoryList = _db.Categories.ToList();
            return dto;
        }
        public void Save(ActivityDTO dto)
        {
            if (dto.Id == 0)
            {
                var model = new Activity
                {
                    CategoryId = dto.CategoryId,
                    Name = dto.Name,
                    Description = dto.Description,
                };
                _db.Activities.Add(model);
            }
            else
            {
                var model = _db.Activities.Find(dto.Id);
                model.Name = dto.Name;
                model.Description = dto.Description;
                model.CategoryId = dto.CategoryId;
                _db.Activities.Update(model);
            }

            _db.SaveChanges();
        }
        public void Delete(int Id)
        {
            var model = _db.Activities.Find(Id);
            _db.Activities.Remove(model);
            _db.SaveChanges();
        }
    }
}

