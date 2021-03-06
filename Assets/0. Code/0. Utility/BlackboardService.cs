namespace Messiah.Utility {
  using System.Collections.Generic;

  public class BlackboardService {
    public static BlackboardService INSTANCE = new BlackboardService();
    private BlackboardService() { }

    private Dictionary<string, Blackboard> blackboards = new Dictionary<string, Blackboard>();

    public Blackboard GetBlackboard(string name) {
      Blackboard blackboard;
      if (!blackboards.TryGetValue(name, out blackboard)) {
        blackboard = new Blackboard(name);
        blackboards[name] = blackboard;
      }
      return blackboard;
    }

    public void DestroyBlackboard(string name) {
      blackboards.Remove(name);
    }


    public class Blackboard {
      public readonly string name;
      internal Blackboard(string name) { this.name = name; }

      private Dictionary<string, object> values = new Dictionary<string, object>();

      public T GetValue<T>(string name) where T : class {
        object o;
        if (values.TryGetValue(name, out o)) return (T)o;
        return null;
      }
      public void SetValue<T>(string name, T t) where T : class {
        values[name] = t;
      }
      public void RemoveValue<T>(string name) where T : class {
        values.Remove(name);
      }

      public void DestroyBlackboard() {
        BlackboardService.INSTANCE.DestroyBlackboard(name);
      }

      ~Blackboard() {
        values.Clear();
      }
    }
  }
}