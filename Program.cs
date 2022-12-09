using System;
using System.Collections;
using System.Diagnostics;
///WAVE file documentation at http://soundfile.sapp.org/doc/WaveFormat/

byte[] fileBytes = File.ReadAllBytes("test_song.wav");

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
//Testing bytesValue Method
Debug.Assert(bytesValue(new byte[]{3, 7, 8, 2}, 0, 0)==0);
Debug.Assert(bytesValue(new byte[]{3, 7, 8, 2}, 0, 1)==3);
Debug.Assert(bytesValue(new byte[]{3, 7, 8, 2}, 2, 1)==8);
Debug.Assert(bytesValue(new byte[]{36, 8, 0, 0}, 0, 4)==2084);

//Decodes and Saves Necessary Meta-Data
Console.WriteLine($"Length of Array: {fileBytes.Length}");
int Array_Length = fileBytes.Length;
Console.WriteLine($"Audio Format: {bytesValue(fileBytes, 20, 2)}");
int Audio_Format = bytesValue(fileBytes, 20, 2);
Console.WriteLine($"Number of Channels: {bytesValue(fileBytes, 22, 2)}");
int Channels = bytesValue(fileBytes, 22, 2);
Console.WriteLine($"Sample Rate: {bytesValue(fileBytes, 24, 4)}");
int Sample_Rate = bytesValue(fileBytes, 24, 4);
Console.WriteLine($"Bits per Sample: {bytesValue(fileBytes, 34, 2)}");
int Bits_Per_Sample = bytesValue(fileBytes, 34, 2);


//defines a functions that takes the starting position of your bytes, and outputs a usable Hz value
int dataToHz_16(int position){
    byte b1 = fileBytes[position];
    byte b2 = fileBytes[position+1];
    var raw_num = BitConverter.ToInt16(new byte[] { b1, b2 }, 0);
    double Hz_value = (0.01* Math.Pow((2), (0.00063876*raw_num)))+37;
    return (int)Hz_value;
}
int dataToHz_8(int position){
    byte b1 = fileBytes[position];

    return 0;
}

//assemble a list of the samples we want to play, stored as a Hz value
List<int> Frequencies = new List<int>();
int Array_Parse_Factor = (Sample_Rate/1000)*Channels;
if (Bits_Per_Sample == 16) Array_Parse_Factor *= 2;

if (Bits_Per_Sample == 16){
for (int i = 44; i < fileBytes.Length; i += Array_Parse_Factor){
    Frequencies.Add(dataToHz_16(i));
    // Console.WriteLine(dataToHz_16(i));
}}
else{
for (int i = 44; i < fileBytes.Length; i += Array_Parse_Factor){
    Frequencies.Add(dataToHz_8(1));
}}
int Frequencies_Length = Frequencies.Count;
Console.WriteLine("Your Song is playing...");
for (int i = 0; i <= Frequencies_Length; i++) Console.Beep(Frequencies[i], 500);