using System;
using System.Collections;
///WAVE file documentation at http://soundfile.sapp.org/doc/WaveFormat/

byte[] fileBytes = File.ReadAllBytes("test_song.wav");
///var bits = new BitArray(fileBytes);

///Verify if the file is a WAVE file
int W = fileBytes[8];
int A = fileBytes[9];
int V = fileBytes[10];
int E = fileBytes[11];
if (W == 87 && A == 65 && V == 86 && E == 69){
    Console.WriteLine("This is a .wav file, the program will continue.");
}
else{
    Console.WriteLine("This is not a .wav file, the program will not work. Please try agin with a .wav file.");
}

///parsed meta data
int sub_chunk1_size = fileBytes[16] + fileBytes[17] + fileBytes[18] + fileBytes[19];
int num_of_channels = fileBytes[22] + fileBytes[23];

for(int i = 0; i < 25; i++){
Console.WriteLine(fileBytes[i]);
}