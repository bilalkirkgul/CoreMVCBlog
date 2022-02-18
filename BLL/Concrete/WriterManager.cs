﻿using BLL.Abstract;
using DAL.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
   public class WriterManager : IWriterService
    {
        IWriterDAL writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            this.writerDAL = writerDAL;
        }
        public void Insert(Writer writer)
        {
            writer.WriterStatus = true;
            writer.WriterAbout = "Deneme";
            //writerDAL.Insert(writer);
        }

        public void Update(Writer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Writer entity)
        {
            throw new NotImplementedException();
        }

        public Writer GetById(int blogId)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

       
    }
}