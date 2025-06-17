using System;
using System.Collections;

struct MatHang
{
    public int MaMH;
    public string TenMH;
    public int SoLuong;
    public float DonGia;

    
    public MatHang(int maMH, string tenMH, int soLuong, float donGia)
    {
        MaMH = maMH;
        TenMH = tenMH;
        SoLuong = soLuong;
        DonGia = donGia;
    }

  
    public float ThanhTien()
    {
        return SoLuong * DonGia;
    }

  
    public void Xuat()
    {
        Console.WriteLine($"Ma: {MaMH}, Ten: {TenMH}, SL: {SoLuong}, Don gia: {DonGia}, Thanh Tien: {ThanhTien()}");
    }
}

class Program
{
    
    static void ThemMH(Hashtable danhsach)
    {
        Console.Write("Nhap ma mat hang: ");
        int ma = int.Parse(Console.ReadLine());

        if (danhsach.ContainsKey(ma))
        {
            Console.WriteLine("mat hang khong co trong danh sach:");
            return;
        }

        Console.Write("Nhap ten mat hang: ");
        string ten = Console.ReadLine();

        Console.Write("Nhap so luong mat hang: ");
        int soLuong = int.Parse(Console.ReadLine());

        Console.Write("Nhap don gia: ");
        float donGia = float.Parse(Console.ReadLine());

        MatHang mh = new MatHang(ma, ten, soLuong, donGia);
        danhsach.Add(ma, mh);
    }

   
    static bool TimMatHang(Hashtable danhsach, int ma)
    {
        return danhsach.ContainsKey(ma);
    }


    static void Xuat(Hashtable danhsach)
    {
        Console.WriteLine("\n DANH SACH MAT HANG");
        foreach (DictionaryEntry entry in danhsach)
        {
            MatHang mh = (MatHang)entry.Value;
            mh.Xuat();
        }
    }

 
    static void XoaMatHang(Hashtable danhsach, int ma)
    {
        if (danhsach.ContainsKey(ma))
        {
            danhsach.Remove(ma);
        }
    }

    static void Main()
    {
        Hashtable danhsach = new Hashtable();
        string tiepTuc;

        
        do
        {
            ThemMH(danhsach);
            Console.Write("co tiep tuc nhap khong : ");
            tiepTuc = Console.ReadLine();
        } while (tiepTuc == "co");

        Xuat(danhsach);

        Console.Write("\nNhap ma mat hang can tim de xoa ");
        int maXoa = int.Parse(Console.ReadLine());

        if (TimMatHang(danhsach, maXoa))
        {
            XoaMatHang(danhsach, maXoa);
        }
        else
        {
            Console.WriteLine("khong tim thay mat hang");
        }

        Xuat(danhsach);
    }
}
