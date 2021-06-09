# RESTful ASP.NET FlightGear

![Alt text](/map.jpg?raw=true "image")

Serves the following URLs: 

### /display/ip/port

Connects to the simulator according the given IP and port, and displays the airplane's location on the map.

### /display/ip/port/frequency

Similar to the previous one, only now presenting the displaying the position in the specified frequency in real time ('frequency' times a second).

### /save/ip/port/frequency/duration/filename

Saves to the file 'filename' the path of the plane until 'duration' seconds have elapsed, according to the specified frequency.

### /display/filename/frequency

Loads the saved path of the plane from 'filename' and displays it according to the specified frequency.
