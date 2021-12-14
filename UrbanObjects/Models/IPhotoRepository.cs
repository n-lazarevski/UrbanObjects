using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.Models
{
    public interface IPhotoRepository
    {
        Photo GetPhoto(int id);
        IEnumerable<Photo> GetAllPhotos();
        IEnumerable<Photo> GetPhotosFromSubcategory(int subcategoryId);
        Photo Add(Photo photo);
        List<Photo> AddPhotos(List<Photo> photos);
        Photo Delete(int id);
    }
}
