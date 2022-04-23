class Stars
{
  int starsNum;
  int maxX;
  int maxY;
  PVector []starsp;
  int meteorNum;
  PVector []position;
  PVector []velocity;
 
  Stars(int num1,int num2,int maxX,int maxY)
  {
    meteorNum=num1;
    starsNum=num2;
    starsp=new PVector[starsNum];
    position=new PVector[meteorNum];
    velocity=new PVector[meteorNum];
   
   
    int x,y;
    float xoff=0.0,yoff=10500.0;
    for (int i=0;i<starsNum;i++)
    {    
       x=int(map(noise(xoff),0,1,0,maxX+200));
       y=int(map(noise(yoff),0,1,0,maxY+0));
       point(x,y);
       starsp[i]= new PVector(x, y);
       yoff+=30;
       xoff+=0.5;
    }
   

    for (int i=0;i<meteorNum;i++)
    {
     x=int(random(maxX));
     y=int(random(maxY));
     position[i]=new PVector(x,y);
     
     x=int(random(1.0,3.0));
     int s = second();
     if(s%2==0){
     x=-x;
     }
     y=int(random(1.0,3.0));
     velocity[i]= new PVector(x, y);
    }
  }

  void display()
  {
    
    stroke(random(255),random(255),random(255));
   for (int i=0;i<meteorNum;i++)
   {
   
    if (i>meteorNum/2)
    { 
   
       point(position[i].x, position[i].y);
      
    
    }
    else
    {
       float size=random(2);
       ellipse(position[i].x, position[i].y,size, size);    
    }
    
   }
   
   for (int i=0;i<starsNum;i++)
   {
    
     if (i%20==0)
     {
       
       
        if(i%150==0){
             stroke(#edccf7);
        int flag=int(random(50));
        float size=random(2,5);
        if(flag>48)
        {
          stroke(67,142,219);
        }
        ellipse(starsp[i].x,starsp[i].y,size, size);
        }else{
        stroke(#edccf7);
        int flag=int(random(50));
        float size=random(1);
        if(flag>48)
        {
          stroke(#edccf7);
        }
        ellipse(starsp[i].x,starsp[i].y,size, size);
        }
        
     }
     else
     {
         
        stroke(#888deb);
        int flag=int(random(50));
        if(flag>48)
        {
          stroke(#edccf7);
        }
        
        point(starsp[i].x,starsp[i].y);
     }
  }
  
  }
  void update(float v)
  {
    
     for (int i=0;i<meteorNum;i++)
     {
       //velocity[i].x = v;
       //velocity[i].y = v;
      PVector vvv =  velocity[i].copy().mult(v);
       
       
      position[i].add(vvv);
     }
  }

void checkEdges()
{  
  for (int i=0;i<meteorNum;i++)
  {
    if (position[i].x > width) 
    {
        position[i].x = 0;
    } else if (position[i].x < 0)
    {
        position[i].x = width;
    }
  
    if (position[i].y > height)
    {
        position[i].y = 0;
    } else if (position[i].y < 0) 
    {
        position[i].y = height;
    }
  }
}
}
