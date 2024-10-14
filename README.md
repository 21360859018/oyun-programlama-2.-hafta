# oyun-programlama-2.-hafta
# Unity Lazer Atış Sistemi

Bu proje, basit bir Unity oyununda lazer atış mekanizmasını içerir. Lazer prefab’i oluşturma, lazerin hareketi ve ekrandan çıktığında yok edilmesi gibi işlemler yapılmıştır.

## Özellikler
- **Lazer Prefab’i**: Kapsül eklenip ölçeklendirildi, materyal ile renklendirildi.
- **Lazer Hareketi**: Yukarı doğru hareket eder, ekran dışına çıkınca yok edilir.
- **Atış Bekleme Süresi**: Atışlar arasında 0.5 saniye bekleme ayarlandı.
- **Atış Fonksiyonu**: `FireLaser()` fonksiyonu ile lazer ateşlenir.


CalculateMovement fonksiyonuyla küpümüzün yani player ın hareket edebileceği yerleri belirliyoruz ve x ekseninde en sona geli dışarı çıkmak istediğinde ekranın en başından çıkmasını sağlıyoruz.
Firelazer  fonksiyonuyla, laserPrefab nesnesini oyuncunun bulunduğu pozisyona yerleştirir. Ayrıca lazerin biraz daha yukarıdan ateşlenmesi için pozisyona new Vector3(0, 0.8f, 0) ekliyoruz. Bu, lazerin tam oyuncu modelinden çıkmak yerine biraz daha yukarıdan görünmesini sağlıyoruz ve Space tuşuna basıldığında lazeri ateşliyoruz.

Lazerin yukarıya doğru sürekli hareket etmesi için her karede (Update() fonksiyonunda) lazerin konumunu değiştiriyoruz. transform.Translate() fonksiyonu ile lazerin Y ekseni boyunca yukarı doğru hareket etmesini sağlıyoruz.
Burada, lazerin sadece Y ekseninde (yani yukarı yönde) hareket etmesi için yeni bir vektör tanımlıyoruz (new Vector3(0, 1, 0)), ve Time.deltaTime ile kare başına birim hareketi ayarlıyoruz.
Lazer yukarı doğru hareket ederken, ekranın üst kısmına ulaştığında yok edilmesi gerekmektedir. Bu sayede gereksiz lazer nesneleri bellek üzerinde yer kaplamaz ve performans optimizasyonu sağlanır. 
•	Update() fonksiyonu içerisinde lazerin Y pozisyonu 7.0’dan büyük olduğunda lazer nesnesini yok ediyoruz.



## Lisans
MIT Lisansı.

