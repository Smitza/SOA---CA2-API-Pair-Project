namespace SOACA2.Tests;

using global::SOACA2.Models;
using global::SOACA2.SOACA2.Tests;
using Xunit;


public class TfQueryTests
{
    private readonly TFQuery _query;
    private readonly TFContext _context;

    public TfQueryTests()
    {
        _context = MockTFContext.Create(); 
        _query = new TFQuery(_context);    
    }

    [Fact]
    public void GetAllCharacters()
    {
        var characters = _query.GetAllCharacters();

        Assert.NotNull(characters);              
        Assert.NotEmpty(characters);             
        Assert.Contains(characters, c => c.name == "Scout");
    }
}
