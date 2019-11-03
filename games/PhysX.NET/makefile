ISDK=/usr/include/PhysX/v2.8.0/SDKs/
LSDK=/usr/lib/PhysX/v2.8.0/
USRLIB=/usr/lib/
CC=g++
CFLAGS=-c -m32 -DLINUX -I$(ISDK)Foundation/include -I$(ISDK)Physics/include -I$(ISDK)PhysXLoader/include -I$(ISDK)Cooking/include -I$(ISDK)NxCharacter/include -I$(ISDK)Physics/include/cloth -I$(ISDK)Physics/include/fluids -I$(ISDK)Physics/include/softbody
LDFLAGS=-m32 -shared -nostdlib -L$(LSDK) -lPhysXLoader -lNxCharacter -lNxCooking
SOURCES=PhysX.NET.cpp PhysX.NET_capi.cpp manual.cpp
OBJECTS=$(SOURCES:.cpp=.o)
LIBRARY=PhysX.so

all: $(SOURCES) $(LIBRARY)

$(LIBRARY): $(OBJECTS)
	$(CC) $(LDFLAGS) $(OBJECTS) -o $@

.cpp.o:
	$(CC) $(CFLAGS) $< -o $@

clean:
	rm -rf *.o PhysX.so