﻿using Abp.Domain.Repositories;
using JPGZService.testmysqldb;
using MagicOnion;
using MagicOnion.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.GrpcService
{
    public class TestService : ServiceBase<ITestService>, ITestService
    {
        private readonly IRepository<Person> _personRepository;
        public TestService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public TestService()
        {

        }
        /// <summary>
        /// Grpc服务
        /// </summary>
        /// <returns></returns>
        public UnaryResult<string> GetTestData()
        {
            var personname = _personRepository.FirstOrDefault(p => p.PersonName != null).PersonName;
            return new UnaryResult<string>(personname);
        }

        public UnaryResult<Person> GetFirstPerson()
        {
            return new UnaryResult<Person>(_personRepository.FirstOrDefault(p => p.PersonName != null));
        }
    }
}
