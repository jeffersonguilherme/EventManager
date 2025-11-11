using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EventManager.Infrastructure;

public class DapperContext
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public DapperContext(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}