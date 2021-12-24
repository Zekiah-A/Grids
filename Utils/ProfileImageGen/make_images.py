import os;
import shutil
from string import ascii_lowercase;
from PIL import Image, ImageDraw, ImageFont;
import random;

width, height = 256, 256
fontsize = 150

assetsPath = '../../Grids.Avalonia/Assets/ProfileImages'

try: #HACK: To prevent image overwriting issues
    shutil.rmtree(assetsPath)
except:
    pass

os.mkdir(assetsPath)

random.seed(341355) #Keyboard spam for complete random

for char in ascii_lowercase: 
    img = Image.new('RGB', (width, height))
    img.putalpha(0) #Transparent background

    d = ImageDraw.Draw(img)
    d.ellipse((0, 0, width, height), fill = (random.randint(0, 255), random.randint(0, 255), random.randint(0, 255)))
    fnt = ImageFont.FreeTypeFont('CooperHewitt-OTF-public/CooperHewitt-Bold.otf', fontsize) # This font is open source, all credit goes to https://github.com/cooperhewitt/cooperhewitt-typeface.
    img_w,img_h = fnt.getsize(char)
    d.text(((width-img_w)/2 + 1, (height-img_h)/2 + 1), char.capitalize(), font=fnt, fill=(0, 0, 0)) #Font shadow!
    d.text(((width-img_w)/2, (height-img_h)/2), char.capitalize(), font=fnt, fill=(205, 205, 205)) #Main font text!
    
    filename = "{assets}/{letter}.png".format(assets = assetsPath, letter = char)
    img.save(filename)
    print(f"Created image {char}.png")    

print(f"Sucessfully created default profile images. Images written to '{assetsPath}'.")