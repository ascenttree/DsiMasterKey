namespace DsiMasterKey;

public class Crc32
{
    public static uint Poly = 0xEDB88320;
    public static uint XorOut = 0xAAAA;
    public static uint AddOut = 0x14C1;

    public static uint Compute(byte[] inbuf)
    {
        uint num = 0xFFFFFFFF;

        foreach (byte b in inbuf)
        {
            num ^= b;
            for (int i = 0; i < 8; i++)
            {
                num = (num >> 1) ^ (Poly & (uint)-(num & 1));
            }
        }

        num ^= XorOut;
        num += AddOut;

        return num;
    }
}