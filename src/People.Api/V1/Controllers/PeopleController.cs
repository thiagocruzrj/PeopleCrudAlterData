using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using People.Api.Controllers;
using People.Api.ViewModels;
using People.Business.Interfaces;
using People.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace People.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/people")]
    public class PeopleController : MainController
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly ILogger<PeopleController> _logger;
        public PeopleController(IPersonRepository personRepository, IPersonService personService, IMapper mapper, INotifier notifier, ILogger<PeopleController> logger) : base(notifier)
        {
            _personRepository = personRepository;
            _personService = personService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonViewModel>> GetAll()
        {
            var person = _mapper.Map<IEnumerable<PersonViewModel>>(await _personRepository.GetById());
            return person;
        }

        [HttpGet("id:guid")]
        public async Task<ActionResult<PersonViewModel>> GetById(Guid id)
        {
            var person = _mapper.Map<PersonViewModel>(await _personRepository.GetById(id));
            if (person == null) return NotFound();
            return person;
        }

        [HttpPost]
        public async Task<ActionResult<PersonViewModel>> Add(PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var photoName = Guid.NewGuid() + "_" + personViewModel.Photo;
            if (!FileUpload(personViewModel.PhotoUpload, photoName))
            {
                return CustomResponse(personViewModel);
            }
            personViewModel.Photo = photoName;
            await _personService.Add(_mapper.Map<Person>(personViewModel));

            return CustomResponse(personViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PersonViewModel>> Update(Guid id, PersonViewModel personViewModel)
        {
            if (id != personViewModel.Id)
            {
                NotifyError("O id informado nao é o mesmo informado na query");
                _logger.LogWarning("Id não encontrado na query");
                return BadRequest();
            }

            var personUpdate = await _personRepository.GetById(id);
            personViewModel.Photo = personUpdate.Photo;
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (personViewModel.PhotoUpload != null)
            {
                var photoName = Guid.NewGuid() + "_" + personViewModel.Photo;
                if (!FileUpload(personViewModel.PhotoUpload, photoName))
                {
                    return CustomResponse(ModelState);
                }

                personUpdate.Photo = photoName;

            }

            personUpdate.Name = personViewModel.Name;
            personUpdate.Email = personViewModel.Email;
            personUpdate.Birthdate = personViewModel.Birthdate;
            personUpdate.WhatsAppNumber = personViewModel.WhatsAppNumber;

            await _personService.Update(_mapper.Map<Person>(personUpdate));
            return CustomResponse(personViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PersonViewModel>> Delete(Guid id)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _personService.Delete(id);
            return CustomResponse();
        }

        private bool FileUpload(string file, string imgName)
        {
            if (string.IsNullOrEmpty(file))
            {
                NotifyError("Forneça uma foto para essa pessoa!");
                _logger.LogWarning("Foto não inserida");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(file);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", imgName);

            if (System.IO.File.Exists(filePath))
            {
                NotifyError("Já existe uma foto com este nome!");
                _logger.LogWarning("Foto inserida com o mesmo nome na pasta raiz.");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
