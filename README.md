# Test-Equipment-shop
a test project presenting a shop equipment and player with stats

## Theory Questions
Q1 - What is a ScriptableObject and why is it useful? When would you use one instead of a
MonoBehaviour?<br>
**ScriptableObject is an object in unity that stores data, without performing actions like Update() or Start(), and without needing a gameObject in order to exist.  it also persists when the scene unloads.<br>
I would use one instead of MonoBehaviour if I want to store data, such as equipment stats bonus, since it takes up less memory to have one ScriptableObject rather than to have a lot of MonoBehavior scripts.** <br>

Q2 - Explain the Single Responsibility Principle in your own words. How would you extend
your system to support new stat types without rewriting existing code? <br>
**The single Responsibility Principle is a principle means that every script only handles one particular action, like PlayerMovement. it is useful to keep the code clean and not to ruin one system when working on another one.<br>
I would make a Scriptable object called "StatData", and a MonoBehavior script called "unitStats" that will be attached to every unit prefab, that holds a List<StatData>, and i will just add new StatData Scriptable to the list with the new dataType**
