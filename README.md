# Texnologiyalar
  * Docker: Ma'lum bir murojaatni umumiy hamma ishlatishi uchun konteynerlashtirish
  * Docker Compose: Ma'lum bir loyhaning barcha xizmatlarini bir joyda ishga tushirishim uchun
  * SQLServer: Ma'lum bir ma'lumotlar bazasini saqlash uchun
  * CQRS, MediatR: Barcha so'rovlar va buyurtmalar uchun CQRS patternini va MediatR kutubxonasini ishlatish
  * Clean Architecture: Loyiha kodlarini tozalash va tuzish uchun masofaviy arxitektura
  * Caching => MemoryCaching: Ma'lumotlar keshlash uchun 
  * JWT: Maxfiylik uchun JSON Web Token (JWT) autentifikatsiyasi
  * API Gateway: Barcha xizmatlarga kirishni boshqarish uchun API Gateway
  * Fluent API: Qulay, chaqaloq va ma'lumotlar kiritish uchun Fluent API ishlatish
## Ishlatish shartlari.
  * Kompyuterda Docker va SQLServer o'rnatyilgan bo'lishi lozim
  * Agar o'rnatilmagan bo'lsa doker uchun: [docker](https://www.docker.com/products/docker-desktop/) sqlServer uchun: [SqlServer](https://aka.ms/ssmsfullsetup)

## Loyiha haqida
Loyiha quyidagi servislarga ega
  * EduCenter
  * Sport
## Loyihani ishga tushirish

1. Loyihani ishga Clone Qilib olinadi.
2. Dockerni ishga tushuriladi.
3. Clone qilingan dasturni ishga tushuramiz.


***POSTMEN da ishlatishni maslahat beraman***

<br />
(example) <br />
**PLEASE USE THIS** <br />
<br />
**GateWayni Porti 9999** <br />

```bash
 http://localhost:9999/
```


<br />
<br />

$${\color{lightgreen}EduCenter \space SERVICE}$$ <br />
**Barcha Get All So'rovlari**\
     - /allGroup\
     - /allRoom\
     - /allSchool\
     - /allStudent\
     - /allTeacher\
     <br />
**Get By Id** (example)\
     - /getIdGroup/id\
     - /getIdRoom/id\
     - /getIdSchool/id\
     - /getIdStudent/id\
     - /getIdTeacher/id\
     <br />
**DELETE** (example)\
     - /deleteIdGroup/id\
     - /deleteIdRoom/id\
     - /deleteIdSchool/id\
     - /deleteIdStudent/id\
     - /deleteIdTeacher/id\
     <br />
**Barcha POST So'rovlari**\
 bodyda jo'natiladi!\
     - /createGroup\
     - /createRoom\
     - /createSchool\
     - /createStudent\
     - /createTeacher\
 <br />
 **PUT** (example)\
 ma'lumotlari bodyda Id esa urlda\
     - /updateGroup\
     - /updateRoom\
     - /updateSchool\
     - /updateStudent\
     - /updateTeacher\
 <br />
$${\color{lightgreen}Sport \space SERVICE}$$ <br />
**Barcha Get All So'rovlari**\
     - /allTeam\
     - /allPlayer\
     - /allOrder\
     - /allCoach\
     <br />
**Get By Id** (example)\
     - /getIdTeam/id\
     - /getIdPlayer/id\
     - //getIdOrder/Id\
     - /getIdCoach/id\
     <br />
**DELETE** (example)\
     - /deleteIdTeam/id\
     - /deleteIdPlayer/id\
     - /deleteIdOrder/Id\
     - /deleteIdCoach/id\
     <br />
**Barcha POST So'rovlari**\
 bodyda jo'natiladi!\
     - /createTeam\
     - /createPlayer\
     - /createOrder\
     - /createCoach\
 <br />
 **PUT** (example)\
 ma'lumotlari bodyda Id esa urlda\
     - /updateTeam\
     - /updatePlayer\
     - /updateOrder\
     - /getIdCoach\
 <br />

# Barcha GetAll Autrizatsiyada Admin roli uchun ochiq
