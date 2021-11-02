using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.Models
{
    public class SQLPhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext context;

        public SQLPhotoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Photo Add(Photo photo)
        {
            context.Photos.Add(photo);
            context.SaveChanges();
            return photo;
        }

        public List<Photo> AddPhotos(List<Photo> photos)
        {
            context.Photos.AddRange(photos);
            context.SaveChanges();
            return photos;
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            return context.Photos;
        }

        public Photo GetPhoto(int id)
        {
            return context.Photos.Find(id);
        }

        public IEnumerable<Photo> GetPhotosFromSubcategory(int subcategoryId)
        {
            return context.Photos.Where<Photo>(p => p.SubcategoryId == subcategoryId);
        }
    }
}
