﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DTOLayer.DTOs.ContactDTOs
{
    public class ContactListDto
    {
        public int Contact3ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
    }
}
