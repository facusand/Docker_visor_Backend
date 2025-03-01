﻿namespace Visor_Backend.DTOs
{
    public class TrabajoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFileCollection? Images { get; set; }
        public List<ImageDto>? ImagesDto { get; set; }
        public List<int>? DeletedImages { get; set; }
        public bool IsDeleted { get; set; }
    }
}
