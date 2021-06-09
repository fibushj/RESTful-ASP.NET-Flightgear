# RESTful ASP.NET FlightGear

Serves the following URLs: 

### /display/ip/port

Connects to the simulator according the given IP and port, and displays the airplane's location on the map.

### /display/ip/port/frequency

Similar to the previous one, only now displaying the position in the specified frequency in real time ('frequency' times a second).

### /save/ip/port/frequency/duration/filename

Samples the locations of the plane for the next 'duration' seconds (according to the specified frequency), and saves the path to the file 'filename'.

### /display/filename/frequency

Loads the saved path of the plane from 'filename' and displays it in animation according to the specified frequency.

![Alt text](/map.jpg?raw=true "image")
