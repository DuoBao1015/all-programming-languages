import processing.sound.*;
import processing.serial.*;
import ddf.minim.*;
AudioPlayer player;
Minim minim;
AudioIn ai;
Amplitude ampl;
Stars myStars;

void setup()
{
  size(1920,1080);
  
  myStars=new Stars(30,5000,1920,1080);
  
  ai = new AudioIn(this,0);
  ai.play();
  
  ampl = new Amplitude(this);
  ampl.input(ai);
  minim = new Minim(this);
  player = minim.loadFile("1.mp3");
  player.loop();
}

void draw()
{
  fill(0,18);
  rect(0,0,width,height);
  float v = ampl.analyze();
  myStars.update(v*10);
  myStars.checkEdges();
  myStars.display();

  

}
