import pygame as pg
import sys
pg.init()

WIN_WIDTH = 900
WIN_HEIGHT = 900

WHITE = (255, 255, 255)

class Ray:
   def __init__(self):
       #Beginning Positions
       self.Source = (WIN_WIDTH/2, WIN_HEIGHT/2)
       self.direction = pg.mouse.get_pos()
       # "Real" Positions of Lightray
       self.x = 0
       self.y = 0
       self.xs = 0
       self.ys = 0
       # Default Rayfactor
       self.factor = 1000
       # List to compare RayIntersection lenghts
       self.f_list = [1000]


   def move(self):
       #Always set the direction to the mouse position
       self.direction = pg.mouse.get_pos()
       #Set the x and y coordinate of the source to the middle and put them in direction tuple
       self.xs = (pg.mouse.get_pos()[0] - WIN_WIDTH/2)
       self.ys = (pg.mouse.get_pos()[1] - WIN_HEIGHT/2)
       self.direction = (self.xs, self.ys)


   def draw(self, screen):
       #Update the background with black so you just see the new line, commeting this gives a cool effect
       screen.fill((0,0,0))
       #Setting the x and y End of Ray Coordinates by mutipying the direction with the factor ( and adding the Half window cause of pygame)
       self.x = self.direction[0] * self.factor + WIN_WIDTH/2
       self.y = self.direction[1] * self.factor + WIN_HEIGHT/2
       #putting x and y in End tuple and draw the line on the screen
       self.End = (self.x, self.y) 
       pg.draw.line(screen, WHITE, self.Source, self.End)

   def checkIntersection(self, Walls):
       print(str(self.direction[0])+ " | " + str(self.direction[1]))
       #Reset List to default Rayfactor
       self.f_list = [1000]
       #Check the Intersection Point with every Wall (Analytische Geometrie)
       for Wall in Walls:
           WallZaehler = self.direction[0]*(Wall.p1[1]-WIN_HEIGHT/2) + self.direction[1]*(WIN_WIDTH/2-Wall.p1[0])
           WallNenner = (Wall.p2[0]-Wall.p1[0])*self.direction[1] - (Wall.p2[1]-Wall.p1[1])*self.direction[0]
           try:
                WallIntersectionParameter = WallZaehler/WallNenner
           except ZeroDivisionError:
                WallIntersectionParameter = WallZaehler/0.001

        #If Intersection Point valid for physical Intersection get the Ray Intersection point
           if WallIntersectionParameter > 0 and WallIntersectionParameter <= 1:
               try:
                   RayIntersection = (Wall.p1[0]+(Wall.p2[0]-Wall.p1[0])*WallIntersectionParameter-WIN_WIDTH/2)/self.direction[0]
               except ZeroDivisionError:
                   RayIntersection = (Wall.p1[0]+(Wall.p2[0]-Wall.p1[0])*WallIntersectionParameter-WIN_WIDTH/2)/0.001
               if RayIntersection > 0:
                   # Add RayIntersection point to list
                   if RayIntersection in self.f_list:
                       pass
                   else:
                       self.f_list.append(RayIntersection)
       # New rayfactor is smallest rayintersectionpoint
       self.factor = min(self.f_list)

#Draw Boundary between 2 points
class Boundary:
    def __init__(self, p1, p2):
        self.p1 = p1
        self.p2 = p2
        self.Boundary_Thickness = 3

    def draw(self, screen):
        pg.draw.line(screen, WHITE, self.p1, self.p2, self.Boundary_Thickness)

#Get everything on ecreen
def Draw_Window(screen, Rays, Boundaries):
    for R in Rays:
        R.draw(screen)

    for B in Boundaries:
        B.draw(screen)

    pg.display.update()

def main():
    Run = True
    screen = pg.display.set_mode((WIN_WIDTH, WIN_HEIGHT))
    clock = pg.time.Clock()

    #Create one Ray and the Walls
    rays = [Ray()]
    Walls = [Boundary((200,150), (200,500)),
             Boundary((400,200), (250,200)),
             Boundary((300,700), (300,300)),
             Boundary((250,800), (650,800)),
             Boundary((200,150), (300,150)),
             Boundary((650,750), (750,600)),
             Boundary((600,200), (600,450)),
             Boundary((600,200), (650,200)),
             Boundary((650,200), (650,100)),
             Boundary((650,100), (300,100))]

    while Run:
        clock.tick(30)
        for event in pg.event.get():
            if event.type == pg.QUIT:
                Run = False
                pg.quit()
                sys.exit(0)
        # Update Ray Position and Intersection points
        for ray in rays:
            ray.move()
            ray.checkIntersection(Walls)

        #Draw
        Draw_Window(screen, rays, Walls)

main()