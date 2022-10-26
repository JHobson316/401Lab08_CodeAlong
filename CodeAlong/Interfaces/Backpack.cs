using System.Collections;
namespace LendingLibrary.Interfaces{
    public interface IBag<T> : IEnumerable<T>
 {
     /// <summary>
     /// Add an item to the bag. <c>null</c> items are ignored.
     /// </summary>
     void Pack(T item);

     /// <summary>
     /// Remove the item from the bag at the given index.
     /// </summary>
     /// <returns>The item that was removed.</returns>
     T Unpack(int index);
 }
 public class Backpack<T> : IBag<T>{
    //Since items need to be unpacked by index
    //Use a private list
    private readonly List<T> stuff = new List<T>();
    public void Pack(T item){
        stuff.Add(item); // Add item to backpack
    }
    public T Unpack(int index){
        // thing is assigned the value of the item at the index in stuff
        // and then removed
        T thing = stuff[index];
        stuff.RemoveAt(index);
        return thing;
    }
    public IEnumerator<T> GetEnumerator(){
        foreach(T thing in stuff)
        yield return thing;
    }
    IEnumerator IEnumerable.GetEnumerator(){
        return GetEnumerator();
    }
 }
}