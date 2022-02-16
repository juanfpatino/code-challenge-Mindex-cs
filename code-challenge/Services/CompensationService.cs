using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class CompensationService: ICompensationService
    {
        private readonly ICompensationRepository _compRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository _compRepository)
        {
            this._compRepository = _compRepository;
            _logger = logger;
        }

        public Compensation Create(Compensation comp)
        {
            if (comp != null)
            {
                _compRepository.Add(comp);
                _compRepository.SaveAsync().Wait();
            }

            return comp;
        }

        public Compensation GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _compRepository.GetById(id);
            }

            return null;
        }

        public Compensation Replace(Compensation originalComp, Compensation newComp)
        {
            if (originalComp != null)
            {
                _compRepository.Remove(originalComp);
                if (newComp != null)
                {
                    // ensure the original has been removed, otherwise EF will complain another entity w/ same id already exists
                    _compRepository.SaveAsync().Wait();

                    _compRepository.Add(newComp);

                }
                _compRepository.SaveAsync().Wait();
            }

            return newComp;
        }

    }
}
