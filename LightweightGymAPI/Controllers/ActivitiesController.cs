using AutoMapper;
using LightweightGymAPI.Dto;
using LightweightGymAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightweightGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivitiesController(IActivityRepository contractorRepository, IMapper mapper)
        {
            _activityRepository = contractorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<Entities.Activity>>> GetAll()
        {
            var activities = await _activityRepository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ActivityDto>>(activities));
        }

        [HttpGet("{activityId}")]
        public async Task<ActionResult<IEnumerable<Entities.Activity>>> GetActivity(int activityId)
        {
            var activity = await _activityRepository.GetAsync(activityId);

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ActivityDto>(activity));
        }

        [HttpPost]
        public async Task<ActionResult<ActivityDto>> CreateActivity(ActivityDto newActivity)
        {
            var activity = _mapper.Map<Entities.Activity>(newActivity);

            _activityRepository.Add(activity);
            await _activityRepository.SaveAsync();

            var createdActivityDto = _mapper.Map<ActivityDto>(activity);
            return CreatedAtAction(nameof(GetActivity), new { activityId = createdActivityDto.ActivityId }, createdActivityDto);
        }
    }
}
