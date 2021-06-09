# RESTful ASP.NET FlightGear

![Alt text](/map.jpg?raw=true "image")

Serves the following URLs: 

### _/display/ip/port_

Connects to the simulator according the given IP and port, and displays the airplane's location on the map.

_/display/ip/port/frequency_

Similar to the previous one, only now presenting the displaying the position in the specified frequency in real time ('frequency' times a second).

_/save/ip/port/frequency/duration/filename_

Saves to the file 'filename' the path of the plane until 'duration' seconds have elapsed, according to the specified frequency.

_/display/filename/frequency_

Loads the saved path of the plane from 'filename' and displays it according to the specified frequency.
