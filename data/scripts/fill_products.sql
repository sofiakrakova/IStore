#Drop data and reset index
DELETE FROM istoredb.products WHERE id>0;
ALTER TABLE istoredb.products AUTO_INCREMENT = 1;

INSERT INTO istoredb.products
VALUES
(
  NULL, 
  'Sony MDRZX110/BLK ZX Series Stereo Headphones (Black)',
  '30 millimeter drivers for rich, full frequency response
Lightweight and comfortable on ear design
Swivel design for portability
47 ¼ inch (1.2 meter) tangle free, Y type cord',
  100.2,
  'images/catalogue/sony.jpg',
    1
),

(
    NULL,
    'Fujifilm Instax Mini 9 Camera',
    'START SNAPPING IN SECONDS – You’ll be the talk of the party and the center of attention with your new FujiFilm Instax Mini 9 Camera.
     It’s simple to use, so anyone can easily achieve crystal clear, vibrant photos in no time. Plus, built-in flash and Fujinon 60mm f/12.7 lens are enclosed in a fun 
     ICE BLUE package that everyone will love using!',
     99.1,
     'images/catalogue/instax.jpg',
     1
),

(
    NULL,
    'SanDisk 64GB Extreme PRO SDXC UHS-I Card - C10, U3, V30, 4K UHD, SD Card - SDSDXXY-064G-GN4IN',
    'Perfect for shooting 4K UHD video(1) and sequential burst mode photography, (1)Full HD (1920x1080) and 
    4K UHD (3840 x 2160) video support may vary based upon host device, file attributes and other factors',
     22.2,
     'images/catalogue/sandisk.jpg',
     1
),

(
    NULL,
    'Panasonic LUMIX GX85 4K Digital Camera',
    'Fine Detail Performance:16 megapixel Micro Four Thirds sensor with no low pass filter resulting in a near 10 percent boost 
    in fine detail resolving power over existing 16 megapixel Micro Four Thirds sensors',
     229.1,
     'images/catalogue/lumia.jpg',
     1
),

(
    NULL,
    'Acer SB220Q bi 21.5 Inches Full HD (1920 x 1080) IPS Ultra-Thin',
    '21.5 inches Full HD (1920 x 1080) widescreen IPS display, And Radeon free sync technology. No compatibility for VESA Mount
Refresh rate: 75 hertz - Using HDMI port',
     95.1,
     'images/catalogue/monitor.jpg',
     2
),


(
    NULL,
    'New GoPro HERO9 Black',
    '5K Video - Shoot stunning video with up to 5K resolution, perfect for maintaining detail even when zooming in
20MP Photo with SuperPhoto - Capture crisp, pro-quality photos with 20MP clarity. 
And with SuperPhoto, HERO 9 Black can automatically pick all the best image processing for you',
     115.13,
     'images/catalogue/gopro.jpg',
     2
),

(
    NULL,
    'Occer 12x25 Compact Binoculars',
    'HIGH-POWERED LARGE EYEPIECE BINOCULARS】 This binoculars has 12x magnification, 25mm objective lens and wide field of view, 
    273ft/1000yds, letting you look farther and see wider. 
    Coating with FMC Broadband coating and premium BAK4 prism, it ensure imaging verisimilar.',
     45.1,
     'images/catalogue/occer.jpg',
     2
),

(
    NULL,
    'SHINE ARMOR Fortify Quick Coat',
    'ADVANCED FORMULA 3 IN 1. Our fortify quick coat is your all in one ceramic coating hydrophobic spray. 
    Shine Armor Fortify Quick Coat ceramic car wax provides a waterless wash, coat and shine, all in one convenient product.',
     15.1,
     'images/catalogue/shinearmor.jpg',
     3
),

(
    NULL,
    'Turtle Wax 53409 Hybrid Solutions Ceramic Spray Coating - 16 Fl Oz.',
    'Super hydrophobic and SiO2 polymers deliver water repelling, water sheeting, and chemical resistant protection that can last up to 12 months
Simply spray on a clean dry car, spread and remove with a folded microfiber cloth; for 
best performance paint should be free of contaminants by using a clay bar or compound prior to application',
     14.5,
     'images/catalogue/turtlewax.jpg',
     3
),

(
    NULL,
    'VIKING 862401 Microfiber Applicator',
    '5" in diameter
Evenly distributes waxes, polish, protectants, and dressings
Perfect for interior and exterior
Machine washable and reusable
6 microfiber pads per pack',
     7.0,
     'images/catalogue/viking.jpg',
     3
),

(
    NULL,
    'Chemical Guys WAC_201_16 Butter Wet Wax',
    '100 percent carnauba based wax
New formulation for even easier application
Deep wet look to any paintwork
Improved level of protection.Date on item is manufactured date
More UVA and UVB protection',
     11.1,
     'images/catalogue/chemicalguys.jpg',
     3
),

(
    NULL,
    'essence | Lash Princess False Lash Effect Mascara | Gluten & Cruelty Free',
    'NO FALSIES NEEDED! Lash Princess False Lash Mascara defines and separates lashes while achieving a bold look.',
    4.99,
    'images/catalogue/essence.jpg',
    4
),

(
    NULL,
    'Pronexa Hairgenics Lavish Lash – Eyelash Growth Enhancer & Brow Serum with Biotin & Natural Growth Peptides for Long, Thick Lashes and Eyebrows! Dermatologist Certified, Cruelty Free & Hypoallergenic.',
    'Our revolutionary botanical serum boosts the length and thickness of eyelashes and eyebrows. The result is longer, fuller and thicker eyelashes and brows! Imparts sheen and luster to lashes and brows making them appear lush and beautiful. No more false lashes needed!
Lavish Lash is proven by science. Experience drastic increases in length and thickness of your eyelashes and eyebrows in as little as 60 days for the perfect lash boost! Contains proprietary botanically-derived compounds that penetrate hair follicles to stimulate lash and brow growth which in turn fortifies the eyelashes and brows to noticeably lengthen and thicken them.',
    29.99, 
    'images/catalogue/lavishlash.jpg',
    4
),
(
    NULL,
    'NYX PROFESSIONAL MAKEUP Epic Ink Liner, Waterproof Liquid Eyeliner, Black',
    'WATERPROOF LIQUID EYELINER: Get the perfect long-lasting cat eye look with NYX PROFESSIONAL MAKEUP Epic Ink eyeliner.
PRECISE TIP: Our ultra-precise tip is flexible and easy to use. Every stroke is unbelievably fluid for a defined finish. Control the thickness of your lines by pressing down just a touch. Fine and natural, broad and bold—the look is always up to you.',
    8.97,
    'images/catalogue/nyx.jpg',
    4
),

(
    NULL,
    'Vont Pyro Bike Light Set, USB Rechargeable Super Bright Bicycle Light, Bike Lights Front and Back, Bike Headlight, 2X Longer Battery Life, Waterproof, 4 Modes (2 Cables, 4 Straps)',
    'SUPER BRIGHT LEDS & FOUR MODES ––– Your new bike light set features extremely bright LEDs which illuminate the entire road. Featuring four different modes of lighting which you can switch with the click of a button. Say goodbye to bulky bike lights with excessive wiring.',
    13.99, 
   'images/catalogue/vont.jpg',
    6
),

(
    NULL,
    'Band-Aid Brand Flexible Fabric Adhesive Bandages for Wound Care & First Aid, Assorted Sizes, 100 ct, Beige',
    '100-count assorted sized Band-Aid Brand Flexible Fabric Adhesive Bandages for first aid and wound protection of minor wounds, cuts, scrapes and burns
Made with Memory-Weave fabric for comfort and flexibility, these bandages stretch, bend, and flex with your skin as you move, and include a Quilt-Aid Comfort Pad designed to cushion painful wounds which may help prevent re-injury',
    6.88, 
    'images/catalogue/band.jpg',
    6
),

(
    NULL,
    'Posture Corrector For Men And Women - Adjustable Upper Back Brace For Clavicle To Support Neck, Back and Shoulder (Universal Fit, U.S. Design Patent)',
    'LET OUR POSTURE CORRECTOR BE PART OF YOUR HEALTHIER LIFE: Our Posture Corrector helps you regain proper posture which can help to prevent the onset of back, neck and shoulder pain. Our Posture Corrector helps provide alignment while sitting, standing, lying down or during your other daily activities. Proper posture is important for all ages and is essential for living a productive life.',
    24.99,
    'images/catalogue/posture.jpg',
     6 
);


#SELECT * FROM istoredb.products;