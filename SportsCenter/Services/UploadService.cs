namespace SportsCenter.Services
{
    public class UploadService
    {
        private readonly IWebHostEnvironment env;
        private readonly string _root;

        public UploadService(IWebHostEnvironment env)
        {
            this.env = env;
            _root = $@"{env.WebRootPath}\System";
        }
        public async Task<Tuple<bool, string>> Upload(IFormFile file, string folderPath)
        {
            if (file == null)
            {
                return new Tuple<bool, string>(false, "");
            }
            var result = await FileCopy(file, folderPath);
            return new Tuple<bool, string>(true, result);
        }
        public async Task<Tuple<bool, List<string>>> Upload(List<IFormFile> files, string folderPath)
        {
            var temp = new List<string>();
            if (!files.Any())
            {
                return new Tuple<bool, List<string>>(false, temp);
            }

            foreach (var file in files)
            {
                temp.Add(await FileCopy(file, folderPath));
            }
            return new Tuple<bool, List<string>>(true, temp);
        }

        public async Task<string> FileCopy(IFormFile file, string folderPath)
        {
            if (file.Length > 0)
            {
                var path = $@"{folderPath}\{DateTime.Now.Ticks}_{file.FileName}";
                using var stream = new FileStream($@"{_root}\{path}", FileMode.Create);
                await file.CopyToAsync(stream);
                return path;
            }
            return "";
        }
    }
}

