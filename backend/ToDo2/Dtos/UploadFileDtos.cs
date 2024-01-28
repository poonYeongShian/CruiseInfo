using System;

namespace ToDo2.Dtos
{
    public class UploadFileDtos
    {
        public Guid UploadFileId { get; set; }
        public string Name { get; set; }
        public string Src { get; set; }
        public Guid TodoId { get; set; }
    }
}
