using System;
using System.Collections;
using System.Diagnostics;
///WAVE file documentation at http://soundfile.sapp.org/doc/WaveFormat/

byte[] fileBytes = File.ReadAllBytes("test_song.wav");
///var bits = new BitArray(fileBytes);

for(int i = 0; i <= 45; i++){
Console.WriteLine($"{i}:  {fileBytes[i],2:x}");
}


int bytesValue(byte[] bytes, int offset, int length){
    if (length == 0)return 0;

    int total = 0;
    int multiplier = 1;
    for (int i = 0; i < length; i++){
        total += bytes[offset + i]*multiplier;
        multiplier *=16*16;
    }
    return total;
}

Console.WriteLine($"Length of Array: {fileBytes.Length}");
Console.WriteLine($"Audio Format: {bytesValue(fileBytes, 20, 2)}");
Console.WriteLine($"Number of Channels: {bytesValue(fileBytes, 22, 2)}");
Console.WriteLine($"Sample Rate: {bytesValue(fileBytes, 24, 4)}");
Console.WriteLine($"Bits per Sample: {bytesValue(fileBytes, 34, 2)}");



Debug.Assert(bytesValue(new byte[]{3, 7, 8, 2}, 0, 0)==0);

Debug.Assert(bytesValue(new byte[]{3, 7, 8, 2}, 0, 1)==3);

Debug.Assert(bytesValue(new byte[]{3, 7, 8, 2}, 2, 1)==8);

Debug.Assert(bytesValue(new byte[]{36, 8, 0, 0}, 0, 4)==2084);

int dataToHz(int position){
    
    return 0;
}


for (int i = 44; i < fileBytes.Length; i += 350000){
    Console.WriteLine($"{fileBytes[i],3} {fileBytes[i+1],3}");
}