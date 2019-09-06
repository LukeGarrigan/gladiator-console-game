
namespace GladiatorGame.Items
{
    public interface Item 
    {
        string Name { get; set; }

        void OutputStats();
    }    
}