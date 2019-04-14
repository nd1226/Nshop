﻿using N.Data.Infrastructure;
using N.Data.Repository;
using N.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Service
{
    public interface IErrorService
    {
        Error Create(Error error);
        void SaveChanges();
    }
    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
        }
        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
