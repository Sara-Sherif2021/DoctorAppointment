﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Doctor.Availability.Dto.Doctor
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }
        public string? Specializations { get; set; }
    }
}
