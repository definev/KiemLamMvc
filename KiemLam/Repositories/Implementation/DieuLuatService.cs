// using MovieStoreMvc.Models.Domain;
// using MovieStoreMvc.Models.DTO;
// using MovieStoreMvc.Repositories.Abstract;
//
// namespace MovieStoreMvc.Repositories.Implementation
// {
//     public class DieuLuatService : IDieuLuatService
//     {
//         private readonly DatabaseContext ctx;
//         public DieuLuatService(DatabaseContext ctx)
//         {
//             this.ctx = ctx;
//         }
//         public bool Add(DieuLuat model)
//         {
//             try
//             {
//                 
//                 ctx.Movie.Add(model);
//                 ctx.SaveChanges();
//                 foreach (int genreId in model.ChuongMuc)
//                 {
//                     var movieGenre = new DieuLuatChuongMuc
//                     {
//                         MovieId = model.Id,
//                         ChuongMucId = genreId
//                     };
//                     ctx.MovieGenre.Add(movieGenre);
//                 }
//                 ctx.SaveChanges();
//                 return true;
//             }
//             catch (Exception ex)
//             {
//                 return false;
//             } 
//         }
//
//         public bool Delete(int id)
//         {
//             try
//             {
//                 var data = this.GetById(id);
//                 if (data == null)
//                     return false;
//                 var movieGenres= ctx.MovieGenre.Where(a => a.MovieId == data.Id);
//                 
//                 foreach(var movieGenre in movieGenres)
//                 {
//                     ctx.MovieGenre.Remove(movieGenre);
//                 }
//                 ctx.Movie.Remove(data);
//                 ctx.SaveChanges();
//                 return true;
//             }
//             catch (Exception ex)
//             {
//                 return false;
//             }
//         }
//
//         public DieuLuat GetById(int id)
//         {
//             return ctx.Movie.Find(id);
//         }
//
//         public DieuLuatListVm List(string term="",bool paging=false, int currentPage=0)
//         {
//             var data = new DieuLuatListVm();
//            
//             var list = ctx.Movie.ToList();
//            
//            
//             if (!string.IsNullOrEmpty(term))
//             {
//                 term = term.ToLower();
//                 list = list.Where(a => a.Name.ToLower().StartsWith(term)).ToList();
//             }
//
//             if (paging)
//             {
//                 // here we will apply paging
//                 int pageSize = 5;
//                 int count = list.Count;
//                 int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
//                 list = list.Skip((currentPage - 1)*pageSize).Take(pageSize).ToList();
//                 data.PageSize = pageSize;
//                 data.CurrentPage = currentPage;
//                 data.TotalPages = TotalPages;
//             }
//
//             foreach (var movie in list)
//             {
//                 var genres = (from genre in ctx.ChuongMuc
//                               join mg in ctx.MovieGenre
//                               on genre.Id equals mg.ChuongMucId
//                               where mg.MovieId == movie.Id
//                               select genre.TenChuong
//                               ).ToList();
//                 var genreNames = string.Join(',', genres);
//                 movie.ChuongMucNames = genreNames;
//             }
//             data.MovieList = list.AsQueryable();
//             return data;
//         }
//
//         public bool Update(DieuLuat model)
//         {
//             try
//             {
//                 // these genreIds are not selected by users and still present is movieGenre table corresponding to
//                 // this movieId. So these ids should be removed.
//                 var genresToDeleted = ctx.MovieGenre.Where(a => a.MovieId == model.Id && !model.ChuongMuc.Contains(a.ChuongMucId)).ToList();
//                 foreach(var mGenre in genresToDeleted)
//                 {
//                     ctx.MovieGenre.Remove(mGenre);
//                 }
//                 foreach (int genId in model.ChuongMuc)
//                 {
//                     var movieGenre = ctx.MovieGenre.FirstOrDefault(a => a.MovieId == model.Id && a.ChuongMucId == genId);
//                     if (movieGenre == null)
//                     {
//                         movieGenre = new DieuLuatChuongMuc { ChuongMucId = genId, MovieId = model.Id };
//                         ctx.MovieGenre.Add(movieGenre);
//                     }
//                 }
//
//                 ctx.Movie.Update(model);
//                 // we have to add these genre ids in movieGenre table
//                 ctx.SaveChanges();
//                 return true;
//             }
//             catch (Exception ex)
//             {
//                 return false;
//             }
//         }
//
//         public List<int> GetGenreByMovieId(int movieId)
//         {
//             var genreIds = ctx.MovieGenre.Where(a => a.MovieId == movieId).Select(a => a.ChuongMucId).ToList();
//             return genreIds;
//         }
//        
//     }
// }
