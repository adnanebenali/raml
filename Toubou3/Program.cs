// See https://aka.ms/new-console-template for more information
using Toubou3;

Console.WriteLine("Hello, World!");

List<Tab3> allToubou3 = new List<Tab3>();


Tab3 elmaya = new Tab3
{
	Name = "E L - M A Y A",
	Short = "MAYA",
	Qarar = Notatt.C,
	Sard = Notatt.E,
	Qotb = Notatt.G,
};

elmaya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

elmaya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up),
					new Nota(Notatt.B, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Up)));

elmaya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Down)));

elmaya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

elmaya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.Bb, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

elmaya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down)));

allToubou3.Add(elmaya);

//////////////////////////////////////////////////////////////////////
///
Tab3 eraq_la3rab = new Tab3
{
	Name = "3 R A Q - L E 3 R A B",
	Short = "3RAQ",
	Qarar = Notatt.E,
	Sard = Notatt.G,
	Qotb = Notatt.G,
};

eraq_la3rab.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up)));

eraq_la3rab.Khalaya.Add(
new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
				new Nota(Notatt.A, NotaDirection.Up),
				new Nota(Notatt.G, NotaDirection.Down)));

eraq_la3rab.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.Fsharp, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Down)));

eraq_la3rab.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Up)));

eraq_la3rab.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

eraq_la3rab.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

allToubou3.Add(eraq_la3rab);

//////////////////////////////////////////////////////////////////////
///
Tab3 al_istihelal = new Tab3
{
	Name = "A L - I S T I H E L A L",
	Short = "STIHLAL",
	Qarar = Notatt.C,
	Sard = Notatt.G,
	Qotb = Notatt.G,
};

al_istihelal.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Up),
					new Nota(Notatt.B, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Up)));

al_istihelal.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

al_istihelal.Khalaya.Add(
new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
				new Nota(Notatt.A, NotaDirection.Up),
				new Nota(Notatt.G, NotaDirection.Down)));

al_istihelal.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

al_istihelal.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

al_istihelal.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

allToubou3.Add(al_istihelal);


//////////////////////////////////////////////////////////////////////
///
Tab3 la7ssin = new Tab3
{
	Name = "L A 7 S S I N",
	Short = "LA7SSIN",
	Qarar = Notatt.D,
	Sard = Notatt.A,
	Qotb = Notatt.G,
};

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up)));

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up)));

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.Fsharp, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up)));

la7ssin.Khalaya.Add(
new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
				new Nota(Notatt.A, NotaDirection.Up),
				new Nota(Notatt.G, NotaDirection.Down)));

la7ssin.Khalaya.Add(
new Khaliyya(new Nota(Notatt.B, NotaDirection.Up),
				new Nota(Notatt.C, NotaDirection.Up),
				new Nota(Notatt.A, NotaDirection.Down)));

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Up)));

la7ssin.Khalaya.Add(
new Khaliyya(new Nota(Notatt.G, NotaDirection.Up),
				new Nota(Notatt.A, NotaDirection.Up),
				new Nota(Notatt.F, NotaDirection.Down)));

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down)));

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

la7ssin.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Up)));


allToubou3.Add(la7ssin);


//////////////////////////////////////////////////////////////////////
///
Tab3 raml_el_maya = new Tab3
{
	Name = "R A M L - E L - M A Y A",
	Short = "RAML'LMAYA",
	Qarar = Notatt.D,
	Sard = Notatt.A,
	Qotb = Notatt.G,
};

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up)));

raml_el_maya.Khalaya.Add(
new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
				new Nota(Notatt.A, NotaDirection.Up),
				new Nota(Notatt.G, NotaDirection.Down)));

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.Bb, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.Bb, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down)));

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

raml_el_maya.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Up)));

allToubou3.Add(raml_el_maya);


//////////////////////////////////////////////////////////////////////
///
Tab3 al_isbahan = new Tab3
{
	Name = "A L - I S B I H A N",
	Short = "SBIHAN",
	Qarar = Notatt.D,
	Sard = Notatt.E,
	Qotb = Notatt.G,
};

al_isbahan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up)));

al_isbahan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up)));

al_isbahan.Khalaya.Add(
new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
				new Nota(Notatt.F, NotaDirection.Up),
				new Nota(Notatt.G, NotaDirection.Up)));

al_isbahan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Down)));

al_isbahan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

al_isbahan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

al_isbahan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

al_isbahan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

al_isbahan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));


allToubou3.Add(al_isbahan);


//////////////////////////////////////////////////////////////////////
///
Tab3 la7jaz_lekbir = new Tab3
{
	Name = "L E 7 J A Z - L E K B I R",
	Short = "LE7JAZ",
	Qarar = Notatt.D,
	Sard = Notatt.A,
	Qotb = Notatt.A,
};

la7jaz_lekbir.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Down)));

la7jaz_lekbir.Khalaya.Add(
new Khaliyya(new Nota(Notatt.Fsharp, NotaDirection.Up),
				new Nota(Notatt.G, NotaDirection.Up),
				new Nota(Notatt.A, NotaDirection.Up)));

la7jaz_lekbir.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

la7jaz_lekbir.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.Fsharp, NotaDirection.Down),
					new Nota(Notatt.Eb, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

la7jaz_lekbir.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

//la7jaz_lekbir.Khalaya.Add(
//	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),	lower
//					new Nota(Notatt.B, NotaDirection.Down),
//					new Nota(Notatt.A, NotaDirection.Down),
//					new Nota(Notatt.G, NotaDirection.Down)));

allToubou3.Add(la7jaz_lekbir);


//////////////////////////////////////////////////////////////////////
///
Tab3 rassd = new Tab3
{
	Name = "R A S S D",
	Short = "RASSD",
	Qarar = Notatt.D,
	Sard = Notatt.E,
	Qotb = Notatt.G,
};

rassd.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up)));

rassd.Khalaya.Add(
new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
				new Nota(Notatt.E, NotaDirection.Up),
				new Nota(Notatt.D, NotaDirection.Down)));

rassd.Khalaya.Add(
new Khaliyya(new Nota(Notatt.Fsharp, NotaDirection.Up),
				new Nota(Notatt.G, NotaDirection.Up),
				new Nota(Notatt.A, NotaDirection.Up)));

rassd.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

rassd.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

allToubou3.Add(rassd);


//////////////////////////////////////////////////////////////////////
///
Tab3 rassd_eddayl = new Tab3
{
	Name = "R A S S D - E D D E Y L",
	Short = "RASSD'DEYL",
	Qarar = Notatt.C,
	Sard = Notatt.E,
	Qotb = Notatt.G,
};

rassd_eddayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up)));

rassd_eddayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.Bb, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

rassd_eddayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

rassd_eddayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

rassd_eddayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Up)));

allToubou3.Add(rassd_eddayl);


//////////////////////////////////////////////////////////////////////
///
Tab3 la7jaz_lemsharqi = new Tab3
{
	Name = "L A 7 J A Z - L E M S H A R Q I",
	Short = "LMSHERQI",
	Qarar = Notatt.D,
	Sard = Notatt.E,
	Qotb = Notatt.A,
};

la7jaz_lemsharqi.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.Fsharp, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

la7jaz_lemsharqi.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

la7jaz_lemsharqi.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.Fsharp, NotaDirection.Down),
					new Nota(Notatt.Eb, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

allToubou3.Add(la7jaz_lemsharqi);


//////////////////////////////////////////////////////////////////////
///
Tab3 sika = new Tab3
{
	Name = "S I K A",
	Short = "SIKA",
	Qarar = Notatt.E,
	Sard = Notatt.E,
	Qotb = Notatt.G,
};

sika.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up)));

sika.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

sika.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Up)));

sika.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

sika.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

sika.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

allToubou3.Add(sika);


//////////////////////////////////////////////////////////////////////
///
Tab3 eraq_la3jam = new Tab3
{
	Name = "3 O R A K   A L - L A 3 J A M",
	Short = "3RAK'L3JAM",
	Qarar = Notatt.G,
	Sard = Notatt.B,
	Qotb = Notatt.D,
};

eraq_la3jam.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up)));

eraq_la3jam.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.Fsharp, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

eraq_la3jam.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

eraq_la3jam.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Up)));

eraq_la3jam.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.Fsharp, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

eraq_la3jam.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

eraq_la3jam.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

allToubou3.Add(eraq_la3jam);


//////////////////////////////////////////////////////////////////////
///
Tab3 l3oushaq = new Tab3
{
	Name = "E L 3 O U S H H A Q",
	Short = "L3OSHAQ",
	Qarar = Notatt.G,
	Sard = Notatt.G,
	Qotb = Notatt.A,
};

l3oushaq.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Down)));

l3oushaq.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

l3oushaq.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Up)));

l3oushaq.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

l3oushaq.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

allToubou3.Add(l3oushaq);



//////////////////////////////////////////////////////////////////////
///
Tab3 ad_dhayl = new Tab3
{
	Name = "A D - D H A Y L",
	Short = "DAYL",
	Qarar = Notatt.C,
	Sard = Notatt.D,
	Qotb = Notatt.G,
};

ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up),
					new Nota(Notatt.B, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Up)));

ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Down)));

ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

allToubou3.Add(ad_dhayl);



//////////////////////////////////////////////////////////////////////
///
Tab3 raml_ad_dhayl = new Tab3
{
	Name = "R A M L   A D - D H A Y L",
	Short = "RAML'DAYL",
	Qarar = Notatt.G,
	Sard = Notatt.B,
	Qotb = Notatt.B,
};

raml_ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up),
					new Nota(Notatt.B, NotaDirection.Up)));

raml_ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

raml_ad_dhayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Up)));

allToubou3.Add(raml_ad_dhayl);


//////////////////////////////////////////////////////////////////////
///
Tab3 hamdan = new Tab3
{
	Name = "H A M D A N",
	Short = "7MDAN",
	Qarar = Notatt.F,
	Sard = Notatt.A,
	Qotb = Notatt.G,
};

hamdan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up)));

hamdan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up)));

hamdan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down)));

hamdan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

hamdan.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

allToubou3.Add(hamdan);

//////////////////////////////////////////////////////////////////////
///
Tab3 inqilab_arraml = new Tab3
{
	Name = "I N Q I L A B    A R - R A M L",
	Short = "NQILAB'RAML",
	Qarar = Notatt.D,
	Sard = Notatt.A,
	Qotb = Notatt.G,
};

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Down)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down)));

inqilab_arraml.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Up)));

allToubou3.Add(inqilab_arraml);


//////////////////////////////////////////////////////////////////////
///
Tab3 zawarkand = new Tab3
{
	Name = "A Z - Z A W A R K A N D",
	Short = "ZAWARK'ND",
	Qarar = Notatt.D,
	Sard = Notatt.D,
	Qotb = Notatt.G,
};

zawarkand.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

zawarkand.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.Fsharp, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

zawarkand.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.Fsharp, NotaDirection.Down),
					new Nota(Notatt.Eb, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

zawarkand.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

allToubou3.Add(zawarkand);


//////////////////////////////////////////////////////////////////////
///
Tab3 lamsharqi_sghir = new Tab3
{
	Name = "L E M S H A R Q I   E S - S G H I R",
	Short = "LMSHARQI'SGHIR",
	Qarar = Notatt.G,
	Sard = Notatt.G,
	Qotb = Notatt.G,
};

lamsharqi_sghir.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.D, NotaDirection.Up),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.Fsharp, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

lamsharqi_sghir.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.Fsharp, NotaDirection.Down),
					new Nota(Notatt.Eb, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

lamsharqi_sghir.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

allToubou3.Add(lamsharqi_sghir);


//////////////////////////////////////////////////////////////////////
///
Tab3 moujanib_addayl = new Tab3
{
	Name = "M O U J A N I B    E D - D A Y L",
	Short = "MOUJANIB'DAYL",
	Qarar = Notatt.D,
	Sard = Notatt.E,
	Qotb = Notatt.A,
};

moujanib_addayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

moujanib_addayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.Fsharp, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

moujanib_addayl.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Up)));

allToubou3.Add(moujanib_addayl);


//////////////////////////////////////////////////////////////////////
///
Tab3 al_7oussar = new Tab3
{
	Name = "A L - 7 O S S A R",
	Short = "L7OSSAR",
	Qarar = Notatt.D,
	Sard = Notatt.A,
	Qotb = Notatt.F,
};

al_7oussar.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up)));

al_7oussar.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Up),
					new Nota(Notatt.G, NotaDirection.Up),
					new Nota(Notatt.A, NotaDirection.Up)));

al_7oussar.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down)));

al_7oussar.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.B, NotaDirection.Down),
					new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down)));

al_7oussar.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.A, NotaDirection.Down),
					new Nota(Notatt.G, NotaDirection.Down),
					new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down)));

al_7oussar.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down)));

al_7oussar.Khalaya.Add(
	new Khaliyya(new Nota(Notatt.F, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Down),
					new Nota(Notatt.E, NotaDirection.Up),
					new Nota(Notatt.C, NotaDirection.Down),
					new Nota(Notatt.D, NotaDirection.Up)));

allToubou3.Add(al_7oussar);


//////////////////////////////////////////////////////////////////////
///

foreach (Tab3 tab3 in allToubou3)
{
	Console.WriteLine(tab3);
}

Sniffer.FindCommonKhalaya(focus: al_isbahan, allToubou3.ToArray());


