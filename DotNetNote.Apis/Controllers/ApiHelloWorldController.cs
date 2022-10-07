using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Apis.Controllers
{
    //[!] 애트리뷰트 라우팅
    [Route("api/[Controller]")]
    [ApiController]
    public class ApiHelloWorldController : ControllerBase
    {
        // GET: api/<ApiHelloWorldController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "안녕하세요?", "반갑습니다." };
        }

        // GET api/<ApiHelloWorldController>/5
        //[HttpGet("{id}")]
        //인라인 제약조건 추가
        [HttpGet("{id:int}")]
        public string Get(int id)
        {
            return $"넘어온 값: {id}";
        }

        // POST api/<ApiHelloWorldController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiHelloWorldController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiHelloWorldController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
