using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Imagifation.Models
{
    public class BlockData
    {
    //    // ID 
    //    public int Id { get; set; }
    //    // Наименование изображения
    //    [Required]
    //    [Display(Name = "Название изображения")]
    //    [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
    //    public string Name { get; set; }

    //    // Внешний ключ Категория
    //    [Display(Name = "Категория")]
    //    public int? CategoryId { get; set; }
    //    public Category Category { get; set; }

    //    // Внешний ключ
    //    // ID Пользователя - обычное свойство
    //    public int? UserId { get; set; }
    //    // Отдел пользователя - Навигационное свойство
    //    public User User { get; set; }

    //    // Внешний ключ
    //    // ID Пользователя - обычное свойство
    //    public int? ExecutorId { get; set; }
    //    // Отдел пользователя - Навигационное свойство
    //    public User Executor { get; set; }
    //
        public string AccountName { get; set; }
        public string ContainerName { get; set; }
        public string BlobName { get; set; }
        public DateTime VersionTimestamp { get; set; }
        public short IsCommited { get; set; }
        public int BlockId { get; set; }
        public int Length { get; set; }
        public int StartOffset { get; set; }
        public string FilePath { get; set; }

        // Внешний ключ
        // ID Пользователя - обычное свойство
        public int? UserId { get; set; }
        // Отдел пользователя - Навигационное свойство
        public User User { get; set; }


    }
}