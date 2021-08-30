using Racooter.DataAccess.DbContext;
using Racooter.DataAccess.Models;
using Racooter.DataAccess.Repository;
using Racooter.DataTransferObjects.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Racooter.DataTransferObjects;
using System.Data;

namespace Racooter.DataAccess.Repositories
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        public Task<AnnouncementDto> GetAnnouncement(Guid? Id);
        public Task<Guid> SaveAnnouncement(AnnouncementDto data, string CurrentUserId);        
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task SaveCategoryAsync(int id, string name);
        Task DeleteCategory(int id);
        Task Approve(Guid guid);
        Task<List<AnnouncementDto>> GetFiltererdAnnouncements(AnnouncementFilter filter, string CurrentUserId);

        Task<string> GetUserIdByUserName(string userName);


        Task AddAnnouncementView(Guid? id);
        Task UploadAnnouncementImages(List<KeyValuePair<string, string>> imagesPaths, string AnnouncementId);
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUser(string Id);
        Task SaveUser(UserDto model);
        Task DeleteUser(string id);
        Task RemoveImage(Guid ImageId);
        Task SaveNewsPost(string Title, string SubTitle, string Content);
        Task DeletePost(int Id);
        Task<List<NewsPost>> GetNewsPostsAsync();
        Task<bool> IsAllowForAnnouncementCreation(string CurrentUserEmail);
        Task DeleteAnnouncement(Guid id);
        Task ReportUser(string UserIdToReport, string CurrentUserId);        
    }

    public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
    {
        private readonly RacooterDbContext _context;
        public AnnouncementRepository(RacooterDbContext context) : base(context)
        {
            _context = context;
        }
        #region Announcements Management
        public async Task<AnnouncementDto> GetAnnouncement(Guid? Id)
        {
            var model = new AnnouncementDto();
            
            if (Id.HasValue)
            {
                model = await GetAll().Where(x => x.AnnouncementId == Id).Select(x => new AnnouncementDto
                {
                    AnnouncementId = x.AnnouncementId,
                    Category = x.Category,
                    CreatedBy = x.SellerInfo.Id,
                    CreatedDate = x.CreatedDate,
                    Date = x.Date,
                    Description = x.Description,
                    IsApprovedByAdmin = x.IsApprovedByAdmin,
                    Price = x.Price,
                    Title = x.Title,
                    Views = x.Views,
                    UserName = x.SellerInfo.FullName,
                    UserEmail = x.SellerInfo.Email,
                    Location = x.Location,
                    PhoneNumber = x.PhoneNumber

                }).FirstOrDefaultAsync();

                model.CategoryString = await _context.Categories.Where(x => x.Id == model.Category).Select(r => r.Name).FirstOrDefaultAsync();

                model.Specification = await _context.Specifications.Where(x => x.AnnouncementId == Id.Value).Select(data => new SpecificationDto
                {
                    BodyType = data.BodyType,
                    BodyTypeSelected = data.BodyTypeSelected,
                    Color = data.Color,
                    Emissions = data.Emissions,
                    EngineSize = data.EngineSize,
                    GearBox = data.GearBox,
                    GetFuelType = data.GetFuelType,
                    FuelTypeSelected = data.FuelTypeSelected,
                    HadAccident = data.HadAccident,
                    HasABS = data.HasABS,
                    HasCruiseControl = data.HasCruiseControl,
                    HasDualZoneClimate = data.HasDualZoneClimate,
                    HasElectricMirrors = data.HasElectricMirrors,
                    HasESP = data.HasESP,
                    HasFullElectricWin = data.HasFullElectricWin,
                    HasHeatedSeats = data.HasHeatedSeats,
                    HasHeatedStWheel = data.HasHeatedStWheel,
                    HasLogHistory = data.HasLogHistory,
                    HasVentedSeats = data.HasVentedSeats,
                    HasWarranty = data.HasWarranty,
                    IsFullOptions = data.IsFullOptions,
                    IsNegotiable = data.IsNegotiable,
                    Make = data.Make,
                    Mileage = data.Mileage,
                    Model = data.Model,
                    NrOfDoors = data.NrOfDoors,
                    Power = data.Power,
                    Year = data.Year,
                }).FirstOrDefaultAsync();

                model.AnnouncementImages = await _context.AnnouncementImages.Where(x => x.AnnouncementId == Id.Value).Select(x => new AnnouncementImageDto
                {
                    AnnouncementId = x.AnnouncementId,
                    AnnouncementImageId = x.AnnouncementImageId,
                    ImagePath = x.ImagePath,
                    Name = x.Name
                }).ToListAsync();

            }

            model.Categories = await _context.Categories.Select(e => new CategoryDto
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
            return model;
        }

        public async Task AddAnnouncementView(Guid? id)
        {
            if (id != null && id != Guid.Empty)
            {
                var announcement = await _context.Announcements.FindAsync(id);
                announcement.Views += 1;
            }
        }
        public async Task<Guid> SaveAnnouncement(AnnouncementDto data, string CurrentUserId)
        {
            if (data.AnnouncementId != null && data.AnnouncementId != Guid.Empty)
            {
                var announcement = _context.Announcements.Where(x => x.AnnouncementId == data.AnnouncementId).FirstOrDefault();
                if (announcement != null)
                {
                    announcement.Category = data.Category;
                    announcement.Date = data.Date;
                    announcement.Description = data.Description;
                    announcement.Title = data.Title;
                    announcement.Price = data.Price;
                    announcement.PhoneNumber = GetUserPhoneNumberById(CurrentUserId);
                    announcement.Location = data.Location;
                }
                if (data.Specification != null)
                {
                    var specification = _context.Specifications.Where(x => x.AnnouncementId == data.AnnouncementId).FirstOrDefault();
                    if (specification != null)
                    {
                        specification.BodyType = data.Specification.BodyType;
                        specification.BodyTypeSelected = GetBodyType(specification.BodyType);
                        specification.Color = data.Specification.Color;
                        specification.Emissions = data.Specification.Emissions;
                        specification.EngineSize = data.Specification.EngineSize;
                        specification.GearBox = data.Specification.GearBox;
                        specification.GetFuelType = data.Specification.GetFuelType;
                        specification.FuelTypeSelected = GetFuelType(specification.GetFuelType);
                        specification.HadAccident = data.Specification.HadAccident;
                        specification.HasABS = data.Specification.HasABS;
                        specification.HasCruiseControl = data.Specification.HasCruiseControl;
                        specification.HasDualZoneClimate = data.Specification.HasDualZoneClimate;
                        specification.HasElectricMirrors = data.Specification.HasElectricMirrors;
                        specification.HasESP = data.Specification.HasESP;
                        specification.HasFullElectricWin = data.Specification.HasFullElectricWin;
                        specification.HasHeatedSeats = data.Specification.HasHeatedSeats;
                        specification.HasHeatedStWheel = data.Specification.HasHeatedStWheel;
                        specification.HasLogHistory = data.Specification.HasLogHistory;
                        specification.HasVentedSeats = data.Specification.HasVentedSeats;
                        specification.HasWarranty = data.Specification.HasWarranty;
                        specification.IsFullOptions = data.Specification.IsFullOptions;
                        specification.IsNegotiable = data.Specification.IsNegotiable;
                        specification.Make = data.Specification.Make;
                        specification.Mileage = data.Specification.Mileage;
                        specification.Model = data.Specification.Model;
                        specification.NrOfDoors = data.Specification.NrOfDoors;
                        specification.Power = data.Specification.Power;
                        specification.Year = data.Specification.Year;                        
                        await _context.SaveChangesAsync();
                    }
                }
                return announcement.AnnouncementId;

            }
            else
            {
                var ann = new Announcement();

                ann.Category = data.Category;
                ann.Date = data.Date;
                ann.Description = data.Description;
                ann.Title = data.Title;
                ann.Price = data.Price;
                ann.CreatedDate = DateTime.Now;
                ann.Views = 0;
                ann.IsApprovedByAdmin = false;                                
                ann.SellerInfo = GetSeller(CurrentUserId);
                ann.Location = data.Location;
                ann.PhoneNumber = GetUserPhoneNumberById(CurrentUserId);

                Add(ann);
                await _context.SaveChangesAsync();

                if (data.Specification != null)
                {
                    var specification = new Specification();
                    specification.AnnouncementId = ann.AnnouncementId;
                    specification.BodyType = data.Specification.BodyType;
                    specification.BodyTypeSelected = GetBodyType(specification.BodyType);
                    specification.Color = data.Specification.Color;
                    specification.Emissions = data.Specification.Emissions;
                    specification.EngineSize = data.Specification.EngineSize;
                    specification.GearBox = data.Specification.GearBox;
                    specification.GetFuelType = data.Specification.GetFuelType;
                    specification.FuelTypeSelected = GetFuelType(specification.GetFuelType);
                    specification.HadAccident = data.Specification.HadAccident;
                    specification.HasABS = data.Specification.HasABS;
                    specification.HasCruiseControl = data.Specification.HasCruiseControl;
                    specification.HasDualZoneClimate = data.Specification.HasDualZoneClimate;
                    specification.HasElectricMirrors = data.Specification.HasElectricMirrors;
                    specification.HasESP = data.Specification.HasESP;
                    specification.HasFullElectricWin = data.Specification.HasFullElectricWin;
                    specification.HasHeatedSeats = data.Specification.HasHeatedSeats;
                    specification.HasHeatedStWheel = data.Specification.HasHeatedStWheel;
                    specification.HasLogHistory = data.Specification.HasLogHistory;
                    specification.HasVentedSeats = data.Specification.HasVentedSeats;
                    specification.HasWarranty = data.Specification.HasWarranty;
                    specification.IsFullOptions = data.Specification.IsFullOptions;
                    specification.IsNegotiable = data.Specification.IsNegotiable;
                    specification.Make = data.Specification.Make;
                    specification.Mileage = data.Specification.Mileage;
                    specification.Model = data.Specification.Model;
                    specification.NrOfDoors = data.Specification.NrOfDoors;
                    specification.Power = data.Specification.Power;
                    specification.Year = data.Specification.Year;
                    _context.Specifications.Add(specification);
                    await _context.SaveChangesAsync();
                }

                return ann.AnnouncementId;
            }
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {

            return await _context.Categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public ApplicationUser GetSeller(string sellerId)
        {
            return _context.Users.Where(x => x.Id == sellerId).FirstOrDefault();
        }

        public string GetBodyType(int bodyTypeInt)
        {
            string result = "";
            switch (bodyTypeInt)
            {
                case 1:
                    result = "Cabrio";
                    break;
                case 2:
                    result = "Sedan";
                    break;
                case 3:
                    result = "Coupe";
                    break;
                case 4:
                    result = "Hatchback";
                    break;
                case 5:
                    result = "SUV";
                    break;

            }
            return result;
        }

        public string GetFuelType(int? fuelTypeInt)
        {
            string result = "";
            switch (fuelTypeInt)
            {
                case 1:
                    result = "Diesel";
                    break;
                case 2:
                    result = "GPL";
                    break;
                case 3:
                    result = "Petrol";
                    break;
                case 4:
                    result = "Electric";
                    break;
                case 5:
                    result = "Hybrid";
                    break;

            }
            return result;
        }

        public async Task Approve(Guid guid)
        {
            var announcement = await _context.Announcements.FindAsync(guid);
            announcement.IsApprovedByAdmin = true;
            _context.Entry(announcement).State = EntityState.Modified;
        }

        public async Task SaveCategoryAsync(int id, string name)
        {
            var category = new Category();
            if (id > 0)
            {
                category = await _context.Categories.FindAsync(id);
                category.Name = name;
                _context.Entry(category).State = EntityState.Modified;
            }
            else
            {
                category.Name = name;
                _context.Categories.Add(category);
            }
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            //await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveFilterByUser(AnnouncementFilter filter, string CurrentUserId)
        {
            var fltr = new SearchFilter();
            bool AnyFieldHaveValue = false;
            if (filter.Category.HasValue)
            {
                AnyFieldHaveValue = true;
                fltr.CategoryId = filter.Category;
            }
            if (!string.IsNullOrEmpty(filter.Make))
            {
                AnyFieldHaveValue = true;
                fltr.Make = filter.Make;
            }
            if (filter.Mileage.HasValue)
            {
                AnyFieldHaveValue = true;
                fltr.Mileage = filter.Mileage;
            }
            if (!string.IsNullOrEmpty(filter.Model))
            {
                AnyFieldHaveValue = true;
                fltr.Model = filter.Model;
            }
            if (filter.Power.HasValue)
            {
                AnyFieldHaveValue = true;
                fltr.Power = filter.Power;
            }
            if (filter.Price.HasValue)
            {
                AnyFieldHaveValue = true;
                fltr.Price = filter.Price;
            }
            if (!string.IsNullOrEmpty(filter.Title))
            {
                AnyFieldHaveValue = true;
                fltr.Title = filter.Title;
            }
            if (filter.Year.HasValue)
            {
                AnyFieldHaveValue = true;
                fltr.Year = filter.Year;
            }
            if (AnyFieldHaveValue)
            {
                fltr.CreatedBy = CurrentUserId;
                fltr.CreatedDate = DateTime.Now;
                _context.SearchFilters.Add(fltr);
                await _context.SaveChangesAsync();
            }

            return AnyFieldHaveValue;

        }
        public async Task<List<AnnouncementDto>> GetFiltererdAnnouncements(AnnouncementFilter filter, string CurrentUserId)
        {
            bool isFilterApplied = false;
            if (!string.IsNullOrEmpty(CurrentUserId))
            {
                isFilterApplied = await SaveFilterByUser(filter, CurrentUserId);
            }

            var query = (from x in _context.Announcements
                         join y in _context.Specifications on x.AnnouncementId equals y.AnnouncementId
                         where x.IsApprovedByAdmin == true
                         select new
                         {
                             Announcement = x,
                             Specification = y
                         });


            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(x => x.Announcement.Title.ToLower().Contains(filter.Title.ToLower()));
            }
            if (filter.Category.HasValue)
            {
                query = query.Where(x => x.Announcement.Category == filter.Category.Value);
            }
            if (!string.IsNullOrEmpty(filter.Make))
            {
                query = query.Where(x => !string.IsNullOrEmpty(x.Specification.Make) && x.Specification.Make.ToLower().Contains(filter.Make.ToLower()));
            }
            if (filter.Mileage.HasValue)
            {
                query = query.Where(x => x.Specification.Mileage.HasValue && x.Specification.Mileage.Value == filter.Mileage.Value);
            }
            if (!string.IsNullOrEmpty(filter.Model))
            {
                query = query.Where(x => !string.IsNullOrEmpty(x.Specification.Model) && x.Specification.Model.ToLower().Contains(filter.Model.ToLower()));
            }
            if (filter.Power.HasValue)
            {
                query = query.Where(x => x.Specification.Power.HasValue && x.Specification.Power.Value == filter.Power.Value);
            }
            if (filter.Price.HasValue)
            {
                query = query.Where(x => x.Announcement.Price <= filter.Price.Value);
            }
            if (filter.Year.HasValue)
            {
                query = query.Where(x => x.Specification.Year.HasValue && x.Specification.Year.Value == filter.Year.Value);
            }

            var data = await query.Select(x => new AnnouncementDto
            {
                AnnouncementId = x.Announcement.AnnouncementId,
                Category = x.Announcement.Category,
                CreatedDate = x.Announcement.CreatedDate,
                Date = x.Announcement.Date,
                Price = x.Announcement.Price,
                Title = x.Announcement.Title,
                Views = x.Announcement.Views,
                CreatedBy = x.Announcement.SellerInfo.Id,
                UserName = x.Announcement.SellerInfo.FullName,
                UserEmail = x.Announcement.SellerInfo.Email,
                PhoneNumber = x.Announcement.PhoneNumber,
                Location = x.Announcement.Location
            }).ToListAsync();


            if (!isFilterApplied && !string.IsNullOrEmpty(CurrentUserId))
            {
                //search engine logic started from here
                List<Guid> TempIDs = new List<Guid>();

                List<AnnouncementDto> newFilteredList = new List<AnnouncementDto>();
                List<AnnouncementDto> tempFilteredList = new List<AnnouncementDto>();
                char FilterColumn = 'A';
                bool isDataAdded = false;
                int tempFilterInt = 0;

                //title filter logic
                var maxOccuredTitle = GetColumnOccurences("Title", CurrentUserId).OrderByDescending(x => x.Count).Select(r => r.ColumnName).FirstOrDefault();
                if (!string.IsNullOrEmpty(maxOccuredTitle))
                {
                    tempFilteredList = data.Where(x => x.Title.ToLower().Contains(maxOccuredTitle.ToLower())).ToList();
                    foreach (var item in tempFilteredList)
                    {
                        if (!TempIDs.Contains(item.AnnouncementId))
                        {
                            item.FilterColumn = FilterColumn;
                            isDataAdded = true;
                        }
                    }
                    if (isDataAdded)
                    {
                        FilterColumn = (Char)(Convert.ToUInt16(FilterColumn) + 1);
                        isDataAdded = false;
                    }
                    TempIDs.AddRange(tempFilteredList.Select(x => x.AnnouncementId).ToList());
                    newFilteredList.AddRange(tempFilteredList);
                    tempFilteredList = new List<AnnouncementDto>();
                }
                //title filter logic end

                //price filter logic
                var maxPriceSearched = GetColumnOccurences("Price", CurrentUserId).OrderByDescending(x => x.Count).Select(r => r.ColumnName).FirstOrDefault();
                if (!string.IsNullOrEmpty(maxPriceSearched))
                {
                    var isNumeric = double.TryParse(maxPriceSearched, out double n);
                    if (isNumeric)
                    {
                        var MaxPrice = Convert.ToDouble(maxPriceSearched);
                        tempFilterInt = Convert.ToInt32(MaxPrice);
                        tempFilteredList = data.Where(x => x.Price <= tempFilterInt).ToList();
                    }
                    foreach (var item in tempFilteredList)
                    {
                        if (!TempIDs.Contains(item.AnnouncementId))
                        {
                            item.FilterColumn = FilterColumn;
                            isDataAdded = true;
                        }
                    }
                    if (isDataAdded)
                    {
                        FilterColumn = (Char)(Convert.ToUInt16(FilterColumn) + 1);
                        isDataAdded = false;
                    }
                    TempIDs.AddRange(tempFilteredList.Select(x => x.AnnouncementId).ToList());
                    newFilteredList.AddRange(tempFilteredList);
                    tempFilteredList = new List<AnnouncementDto>();
                }
                //price filter logic end


                //model logic start
                var maxModelSearched = GetColumnOccurences("Model", CurrentUserId).OrderByDescending(x => x.Count).Select(r => r.ColumnName).FirstOrDefault();
                if (!string.IsNullOrEmpty(maxModelSearched))
                {
                    tempFilteredList = data.Where(x => !string.IsNullOrEmpty(x.Specification.Model) && x.Specification.Model.ToLower().Contains(maxModelSearched.ToLower())).ToList();

                    foreach (var item in tempFilteredList)
                    {
                        if (!TempIDs.Contains(item.AnnouncementId))
                        {
                            item.FilterColumn = FilterColumn;
                            isDataAdded = true;
                        }
                    }
                    if (isDataAdded)
                    {
                        FilterColumn = (Char)(Convert.ToUInt16(FilterColumn) + 1);
                        isDataAdded = false;
                    }
                    TempIDs.AddRange(tempFilteredList.Select(x => x.AnnouncementId).ToList());
                    newFilteredList.AddRange(tempFilteredList);
                    tempFilteredList = new List<AnnouncementDto>();
                }
                //model logic start end

                //make logic start
                var maxMakeSearched = GetColumnOccurences("Make", CurrentUserId).OrderByDescending(x => x.Count).Select(r => r.ColumnName).FirstOrDefault();
                if (!string.IsNullOrEmpty(maxMakeSearched))
                {

                    tempFilteredList = data.Where(x => !string.IsNullOrEmpty(x.Specification.Make) && x.Specification.Make.ToLower().Contains(maxMakeSearched.ToLower())).ToList();

                    foreach (var item in tempFilteredList)
                    {
                        if (!TempIDs.Contains(item.AnnouncementId))
                        {
                            item.FilterColumn = FilterColumn;
                            isDataAdded = true;
                        }
                    }
                    if (isDataAdded)
                    {
                        FilterColumn = (Char)(Convert.ToUInt16(FilterColumn) + 1);
                        isDataAdded = false;
                    }
                    TempIDs.AddRange(tempFilteredList.Select(x => x.AnnouncementId).ToList());
                    newFilteredList.AddRange(tempFilteredList);
                    tempFilteredList = new List<AnnouncementDto>();
                }
                //make logic start end

                //year logic start
                var maxYearSearched = GetColumnOccurences("Year", CurrentUserId).OrderByDescending(x => x.Count).Select(r => r.ColumnName).FirstOrDefault();
                if (!string.IsNullOrEmpty(maxYearSearched))
                {
                    var isNumeric = int.TryParse(maxYearSearched, out int n);
                    if (isNumeric)
                    {
                        tempFilterInt = Convert.ToInt32(maxYearSearched);
                        tempFilteredList = data.Where(x => x.Specification.Year <= tempFilterInt).ToList();
                    }
                    foreach (var item in tempFilteredList)
                    {
                        if (!TempIDs.Contains(item.AnnouncementId))
                        {
                            item.FilterColumn = FilterColumn;
                            isDataAdded = true;
                        }
                    }
                    if (isDataAdded)
                    {
                        FilterColumn = (Char)(Convert.ToUInt16(FilterColumn) + 1);
                        isDataAdded = false;
                    }
                    TempIDs.AddRange(tempFilteredList.Select(x => x.AnnouncementId).ToList());
                    newFilteredList.AddRange(tempFilteredList);
                    tempFilteredList = new List<AnnouncementDto>();
                }
                //year logic start end

                //mileage logic start
                var maxMileageSearched = GetColumnOccurences("Mileage", CurrentUserId).OrderByDescending(x => x.Count).Select(r => r.ColumnName).FirstOrDefault();
                if (!string.IsNullOrEmpty(maxMileageSearched))
                {
                    var isNumeric = int.TryParse(maxMileageSearched, out int n);
                    if (isNumeric)
                    {
                        tempFilterInt = Convert.ToInt32(maxMileageSearched);
                        tempFilteredList = data.Where(x => x.Specification.Mileage <= tempFilterInt).ToList();
                    }
                    foreach (var item in tempFilteredList)
                    {
                        if (!TempIDs.Contains(item.AnnouncementId))
                        {
                            item.FilterColumn = FilterColumn;
                            isDataAdded = true;
                        }
                    }
                    if (isDataAdded)
                    {
                        FilterColumn = (Char)(Convert.ToUInt16(FilterColumn) + 1);
                        isDataAdded = false;
                    }
                    TempIDs.AddRange(tempFilteredList.Select(x => x.AnnouncementId).ToList());
                    newFilteredList.AddRange(tempFilteredList);
                    tempFilteredList = new List<AnnouncementDto>();
                }
                //mileage logic start end


                //Power logic start
                var maxPowerSearched = GetColumnOccurences("Power", CurrentUserId).OrderByDescending(x => x.Count).Select(r => r.ColumnName).FirstOrDefault();
                if (!string.IsNullOrEmpty(maxPowerSearched))
                {
                    var isNumeric = int.TryParse(maxPowerSearched, out int n);
                    if (isNumeric)
                    {
                        tempFilterInt = Convert.ToInt32(maxPowerSearched);
                        tempFilteredList = data.Where(x => x.Specification.Power <= tempFilterInt).ToList();
                    }
                    foreach (var item in tempFilteredList)
                    {
                        if (!TempIDs.Contains(item.AnnouncementId))
                        {
                            item.FilterColumn = FilterColumn;
                            isDataAdded = true;
                        }
                    }
                    if (isDataAdded)
                    {
                        FilterColumn = (Char)(Convert.ToUInt16(FilterColumn) + 1);
                        isDataAdded = false;
                    }
                    TempIDs.AddRange(tempFilteredList.Select(x => x.AnnouncementId).ToList());
                    newFilteredList.AddRange(tempFilteredList);
                    tempFilteredList = new List<AnnouncementDto>();
                }
                //Power logic start end

                //category logic start
                var maxCategoryIdSearched = GetColumnOccurences("CategoryId", CurrentUserId).OrderByDescending(x => x.Count).Select(r => r.ColumnName).FirstOrDefault();
                if (!string.IsNullOrEmpty(maxCategoryIdSearched))
                {
                    var isNumeric = int.TryParse(maxCategoryIdSearched, out int n);
                    if (isNumeric)
                    {
                        tempFilterInt = Convert.ToInt32(maxCategoryIdSearched);
                        tempFilteredList = data.Where(x => x.Category == tempFilterInt).ToList();
                    }
                    foreach (var item in tempFilteredList)
                    {
                        if (!TempIDs.Contains(item.AnnouncementId))
                        {
                            item.FilterColumn = FilterColumn;
                            isDataAdded = true;
                        }
                    }
                    if (isDataAdded)
                    {
                        FilterColumn = (Char)(Convert.ToUInt16(FilterColumn) + 1);
                        isDataAdded = false;
                    }
                    TempIDs.AddRange(tempFilteredList.Select(x => x.AnnouncementId).ToList());
                    newFilteredList.AddRange(tempFilteredList);
                    tempFilteredList = new List<AnnouncementDto>();
                }
                //category logic start end


                //this will be the end process
                newFilteredList.AddRange(data.Where(x => !TempIDs.Contains(x.AnnouncementId)).ToList());
                //search engine logic end

                data = new List<AnnouncementDto>();
                data.AddRange(newFilteredList);

                data = data.OrderByDescending(x => x.FilterColumn).ToList();
            }



            var announcementIds = data.Select(x => x.AnnouncementId).ToList();

            var allImages = await _context.AnnouncementImages.Where(x => announcementIds.Contains(x.AnnouncementId.Value)).Select(x => new
            {
                ImagePath = x.ImagePath,
                AnnouncementId = x.AnnouncementId
            }).ToListAsync();

            var categories = await _context.Categories.ToListAsync();

            foreach (var item in data)
            {
                item.ImagesPath = allImages.Where(x => x.AnnouncementId == item.AnnouncementId).Select(x => x.ImagePath).ToList();
                item.CategoryString = categories.Where(x => x.Id == item.Category).Select(r => r.Name).FirstOrDefault();
                item.FilterColumn = item.FilterColumn == '\0' ? Char.MinValue : item.FilterColumn;
                bool isOk = item.FilterColumn == '\0';
            }

            return data;
        }

        private List<ResponseDto> GetColumnOccurences(string ColumnName, string CurrentUserId)
        {
            ColumnName = ColumnName.Trim();
            string _query = "SELECT " + ColumnName + " as ColumnName, COUNT(" + ColumnName + ") AS Count FROM SearchFilters WHERE CreatedBy='" + CurrentUserId + "' GROUP BY " + ColumnName + " ORDER BY Count DESC";
            var entities = new List<ResponseDto>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = _query;
                command.CommandType = CommandType.Text;
                context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        entities.Add(new ResponseDto
                        {
                            ColumnName = result["ColumnName"].ToString(),
                            Count = result["Count"] != null ? Convert.ToInt32(result["Count"]) : 0
                        });
                    }
                }
            }
            return entities;
        }



        public async Task<string> GetUserIdByUserName(string userName)
        {
            return await _context.Users.Where(x => x.UserName == userName).Select(r => r.Id).FirstOrDefaultAsync();
        }

        public string GetUserPhoneNumberById(string CurrentUserId)
        {
            return _context.Users.Where(x => x.Id == CurrentUserId).Select(r => r.PhoneNumber).FirstOrDefault();
        }


        public async Task UploadAnnouncementImages(List<KeyValuePair<string, string>> imagesPaths, string AnnouncementId)
        {
            foreach (var item in imagesPaths)
            {
                var image = new AnnouncementImage();
                image.AnnouncementId = Guid.Parse(AnnouncementId);
                image.ImagePath = item.Value;
                image.Name = item.Key;
                _context.AnnouncementImages.Add(image);
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveImage(Guid ImageId)
        {
            var image = await _context.AnnouncementImages.FindAsync(ImageId);
            if (image != null)
            {
                _context.AnnouncementImages.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        #endregion

        #region Users Management
        public async Task<List<UserDto>> GetAllUsers()
        {
            var data = await _context.Users.Select(x => new UserDto
            {
                Email = x.Email,
                FullName = x.FullName,
                id = x.Id,
                IsBlockFromPost = x.IsBlockFromPost ?? false,
                IsReportedForBlock = x.IsReportedForBlock ?? false,
                ReportedBy = x.ReportedBy,
                Role = ""
            }).ToListAsync();

            var reportedBy_IDs = await _context.Users.Where(x => !string.IsNullOrEmpty(x.ReportedBy)).Select(r => r.ReportedBy).ToListAsync();

            var reportedByUsers = await _context.Users.Where(x => reportedBy_IDs.Contains(x.Id)).Select(x => new
            {
                UserId = x.Id,
                Name=x.FullName
            }).ToListAsync();
            foreach (var item in data)
            {
                if (!string.IsNullOrEmpty(item.ReportedBy))
                {
                    item.ReportedBy = reportedByUsers.Where(x => x.UserId == item.ReportedBy).Select(r => r.Name).FirstOrDefault();
                }
            }
            return data;
        }

        public async Task<UserDto> GetUser(string Id)
        {
            return await _context.Users.Where(x => x.Id == Id).Select(x => new UserDto
            {
                Email = x.Email,
                FullName = x.FullName,
                id = x.Id,
                IsBlockFromPost = x.IsBlockFromPost ?? false,
                IsReportedForBlock = x.IsReportedForBlock ?? false,
                ReportedBy = x.ReportedBy,
                Role = ""
            }).FirstOrDefaultAsync();
        }


        public async Task SaveUser(UserDto model)
        {
            var user = await _context.Users.FindAsync(model.id);
            if (user != null)
            {
                user.FullName = model.FullName;
                user.IsBlockFromPost = model.IsBlockFromPost;
                user.IsReportedForBlock = model.IsReportedForBlock;
            }
        }

        public async Task DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var userRole = await (from usr in _context.Users
                                  join ur in _context.UserRoles on usr.Id equals ur.UserId
                                  join r in _context.Roles on ur.RoleId equals r.Id
                                  select r).FirstOrDefaultAsync();
            if (userRole.Name != "Admin")
            {
                _context.Users.Remove(user);
            }
        }

        #endregion

        public async Task SaveNewsPost(string Title, string SubTitle, string Content)
        {
            var newsPost = new NewsPost()
            {
                Content = Content,
                CreatedDate = DateTime.Now,
                SubTitle = SubTitle,
                Title = Title
            };
            _context.NewsPosts.Add(newsPost);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePost(int Id)
        {
            var post = await _context.NewsPosts.FindAsync(Id);
            if (post != null)
            {
                _context.NewsPosts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NewsPost>> GetNewsPostsAsync()
        {
            return await _context.NewsPosts.OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        public async Task<bool> IsAllowForAnnouncementCreation(string CurrentUserEmail)
        {
            var user = await _context.Users.Where(x => x.UserName == CurrentUserEmail).FirstOrDefaultAsync();
            if (user != null)
            {
                return (user.IsBlockFromPost.HasValue ? !user.IsBlockFromPost.Value : false);
            }
            return false;
        }

        public async Task DeleteAnnouncement(Guid id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement != null)
            {
                var specifications = _context.Specifications.Where(x => x.AnnouncementId == announcement.AnnouncementId).AsEnumerable();
                var announcementImages = _context.AnnouncementImages.Where(x => x.AnnouncementId == announcement.AnnouncementId).AsEnumerable(); 
                _context.Specifications.RemoveRange(specifications);
                _context.AnnouncementImages.RemoveRange(announcementImages);
                _context.Announcements.Remove(announcement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ReportUser(string UserIdToReport, string CurrentUserId)
        {
            var user = await _context.Users.FindAsync(UserIdToReport);
            if (user != null)
            {
                user.ReportedBy = CurrentUserId;
                user.IsReportedForBlock = true;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
