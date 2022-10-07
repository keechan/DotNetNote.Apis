using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Apis.Controllers
{
    //[!] 애트리뷰트 라우팅
    [Route("api/[Controller]")]
    [ApiController]
    public class ApiHelloWorldWithValueController : ControllerBase
    {
        // GET: api/<ApiHelloWorldController>
        [HttpGet]
        public IEnumerable<Value> Get()
        {
            //return new string[] { "안녕하세요?", "반갑습니다." };
            return new Value[] { 
                new Value { Id = 1, Text = "안녕하세요" }, 
                new Value { Id = 2, Text = "반갑습니다." } };
        }

        // GET api/<ApiHelloWorldController>/5
        //[HttpGet("{id}")]
        //인라인 제약조건 추가
        //[1]
        [HttpGet("{id:int}")]
        public Value Get(int id)
        {
            //return $"넘어온 값: {id}";
            return new Value { Id = id, Text = $"넘어온 값: {id}" };
        }

        //[2]
        [HttpPost]
        [Produces(typeof(Value))]
        public IActionResult Post([FromBody]Value value)
        {
            //Chrome://apps의 POSTMAN, Swagger, Fiddler 등의 외부 도구로 테스트

            //TODO: 넘어온 JSON 데이터를 DB에 저장 후 Id 값 반환
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }
    }

    //포맷터 : JSON, XML
    public class Value
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
