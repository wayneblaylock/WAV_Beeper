using System;
using System.Collections;


byte[] fileBytes = File.ReadAllBytes("test_song.wav");
var bits = new BitArray(fileBytes);

for(int i = 0; i < bits.Length; i++){
Console.WriteLine(bits[i]);
}