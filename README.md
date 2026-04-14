# Test-Equipment-shop
a test project presenting a shop equipment and player with stats

## 📂 Project Structure 
   - /Assets
     -  /Prefabs       # Reusable game objects (title bars, coin)
     -  /Scriptables   # Data-driven architecture (equipment, stats)
     -  /Scripts       # C# scripts
     -  /Sprites       # Sprites (downloaded from the internet)

## how systems work
the shop holds a List of EquipmentData Scriptable Objects for the equipments you can buy. <br>
when you buy an item it goes to your inventory, in a List of EquipmentData. <br>
when you equip an equipment from your inventory, it adds its bonuses to your Stats Scriptable Objects. <br>
the playerMovement script uses GetComponent<playerStats> to access your movementSpeed stat, in order to determine your extra speed.
(i could make another class that takes your movementSpeed stat and adds it to your extra speed in PlayerMovement.cs, but i thought it would be more clean for the playerMovement to take it itself, since it is a core stat.)

## Limitations
if the test would specify more tasks i would do them too, no problem (;
there was no limitation in the execution of this simple test.

## Theory Questions
Q1 - What is a ScriptableObject and why is it useful? When would you use one instead of a
MonoBehaviour?<br>
**ScriptableObject is an object in unity that stores data, without performing actions like Update() or Start(), and without needing a gameObject in order to exist.  it also persists when the scene unloads.<br>
I would use one instead of MonoBehaviour if I want to store data, such as equipment stats bonus, since it takes up less memory to have one ScriptableObject rather than to have a lot of MonoBehavior scripts.** <br>

Q2 - Explain the Single Responsibility Principle in your own words. How would you extend
your system to support new stat types without rewriting existing code? <br>
**The single Responsibility Principle is a principle means that every script only handles one particular action, like PlayerMovement. it is useful to keep the code clean and not to ruin one system when working on another.<br>
I would make a Scriptable object called "StatData", and a MonoBehavior script called "unitStats" that will be attached to every unit prefab, that holds a List of StatData, and i will just add new StatData Scriptable objects to the list with the new dataType**
