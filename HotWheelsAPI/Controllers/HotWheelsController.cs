using AutoMapper;
using FluentValidation;
using HotWheels.App.Application;
using HotWheelsApp.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace HotWheelsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]    
    public class HotWheelsController : ControllerBase
    {
        private readonly IHotWheelsRepositary _respositary;
        private readonly IMapper _mapper;
        private readonly IValidator<HotWheel> _hotWheelValidator;

        public HotWheelsController(IHotWheelsRepositary repositary,IMapper mapper,IValidator<HotWheel> hotWheelValidator)
        {
            _respositary = repositary;
            _mapper = mapper;
            _hotWheelValidator = hotWheelValidator;
        }

        [HttpGet(Name = "GetHotWheels")]
        [SwaggerResponse(StatusCodes.Status200OK,Type = typeof(HotWheelsEnvelope))]
        public async Task<ActionResult<HotWheelsEnvelope>> GetAllHotWheels()
        {
            var dbEntities = await _respositary.GetAll();
            var DTO = _mapper.Map<List<HotWheelDTO>>(dbEntities);

            return Ok(new HotWheelsEnvelope()
            {
                HotWheels = DTO,
                Count = DTO.Count
            });
        }

        [HttpGet("{id}",Name ="GetHotWheel")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(HotWheelEnvelope))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HotWheelEnvelope>> GetHotWheel(int id)
        {
            var dbEntity = await _respositary.Get(id);
            if (dbEntity == null)
            {
                return NotFound();
            }
            var DTO = _mapper.Map<HotWheelDTO>(dbEntity);
            return Ok(new HotWheelEnvelope
            {
                HotWheel = DTO
            });
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(HotWheel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(HotWheel))]
        public async Task<ActionResult<HotWheelEnvelope>> PostHotWheel(HotWheelDTO hotWheel)
        {
            var dbEntity = _mapper.Map<HotWheel>(hotWheel);
            var validationresult = await _hotWheelValidator.ValidateAsync(dbEntity);

            if (validationresult.IsValid == false)
            {
                return BadRequest(validationresult.Errors);
            }

            await _respositary.Add(dbEntity);

            var dto = _mapper.Map<HotWheelDTO>(dbEntity);
            return CreatedAtAction(nameof(GetHotWheel), new { id = hotWheel.Id }, new HotWheelEnvelope
            {
                HotWheel = dto
            });            
        }

        [HttpPut("{id}",Name = "UpdateHotWheel")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PutHotWheel(int id,HotWheel hotWheel)
        {           
            
            if(id != hotWheel.Id)
            {
                return BadRequest();
            }
            try
            {
                await _respositary.Put(hotWheel);
                return NoContent();
            }catch(Exception e)
            {
                var existingEntry = await _respositary.Get(id);
                if(existingEntry == null)
                {
                    return NotFound();
                }
                throw;
            }           
        }
        [HttpDelete("{id}",Name = "DeleteHotWheel")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHotWheel(int id)
        {
            var itemForDeletion = await _respositary.Get(id);
            if (itemForDeletion == null)
            {
                return NotFound();
            }
            await _respositary.Delete(itemForDeletion);
            return NoContent();
        }
    }
}