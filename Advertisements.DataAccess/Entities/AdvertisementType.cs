﻿using System.Collections.Generic;

namespace Advertisements.DataAccess.Entities
{
    public class AdvertisementType : IEntity
    {
        public bool IsDeleted { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Advertisement> Advertisements { get; set; }
    }
}