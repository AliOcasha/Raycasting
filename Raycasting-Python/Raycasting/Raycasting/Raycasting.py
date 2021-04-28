import pygame as pg
pg.init()

WIN_WIDTH = 900
WIN_HEIGHT = 900

WHITE = (255, 255, 255)

class Ray:
   def __init__(self):
       self.pos = (WIN_WIDTH/2, WIN_HEIGHT/2)
       self.rawpos = (0,0)
       self.x = 0.1
       self.y = 0.1
       self.xr = 0.1
       self.yr = 0.1
       self.factor = 10
       

   def move(self):
       self.rawpos = pg.mouse.get_pos()
       self.xr = self.rawpos[0]
       self.yr = self.rawpos[1]
       self.rawpos = (self.xr, self.yr)


   def draw(self, screen):
       screen.fill((0,0,0))        
       self.x = self.rawpos[0] + 100* self.factor
       self.y = self.rawpos[1] + 50* self.factor
       self.pos = (self.x, self.y)      
       pg.draw.line(screen, WHITE, pg.mouse.get_pos(), self.pos)

   def checkIntersection(self, Wall):
       WallIntersectionParameter = (self.rawpos[0]*(Wall.p1[1]-pg.mouse.get_pos()[1]) + self.rawpos[1]*(pg.mouse.get_pos()[0]-Wall.p1[0]))/((Wall.p2[0]-Wall.p1[0])*self.rawpos[1] - (Wall.p2[1]-Wall.p1[1])*self.rawpos[0])

       if WallIntersectionParameter > 0 and WallIntersectionParameter < 1:
           RayIntersection = (Wall.p1[0]+(Wall.p2[0]-Wall.p1[0])*WallIntersectionParameter-pg.mouse.get_pos()[0])/self.rawpos[0]
           if RayIntersection > 0:
               self.factor = RayIntersection
           else:
               self.factor = 10
               self.x = self.rawpos[0] + 100* self.factor
               self.y = self.rawpos[1] + 50* self.factor
               self.pos = (self.x, self.y)


class Boundary:
    def __init__(self, p1, p2):
        self.p1 = p1
        self.p2 = p2
        self.Boundary_Thickness = 3

    def draw(self, screen):
        pg.draw.line(screen, WHITE, self.p1, self.p2, self.Boundary_Thickness)

def Draw_Window(screen, Line, Boundaries):
    Line.draw(screen)

    for B in Boundaries:
        B.draw(screen)
    pg.display.update()

def main():
    Run = True
    screen = pg.display.set_mode((WIN_WIDTH, WIN_HEIGHT))
    clock = pg.time.Clock()

    ray = Ray()
    Walls = [Boundary((200,150), (250,500))]

    while Run:
        clock.tick(30)
        for event in pg.event.get():
            if event.type == pg.QUIT:
                Run = False
                pg.quit()
                sys.exit(0)
        ray.move()
        ray.checkIntersection(Walls[0])
        Draw_Window(screen, ray, Walls)

main()
