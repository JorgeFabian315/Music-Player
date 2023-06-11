using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using Music_Player.Models;
using System.Threading.Tasks;

namespace Music_Player.Profile
{
    public static class CancionProfile
    {

        static public object  Initialize()
        {
               var config = new MapperConfiguration(
                   cfg =>
                   {
                       cfg.CreateMap<Cancion, Cancion>();
                   });

                var mapper = config.CreateMapper();
               
                return mapper;
            }
        }
    }

