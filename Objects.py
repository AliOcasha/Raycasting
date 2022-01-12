import pygame as pg
from pygame import fastevent

WHITE = (255, 255, 255)
BLACK = (0,0,0)
# posV and dirV in Format (x,y)
class Ray:
    def __init__(self,dirV):
        self.OrtsVektor = [0,0]
        self.DirectionVector = dirV
        self.factor = 1
        self.TheoreticalCollisionPoint = [0,0]
        self.Endpoint = (0,0)

    def move(self):
        self.OrtsVektor[0] = pg.mouse.get_pos()[0]
        self.OrtsVektor[1] = pg.mouse.get_pos()[1]

        self.TheoreticalCollisionPoint[0] = self.OrtsVektor[0] + self.DirectionVector[0] * self.factor
        self.TheoreticalCollisionPoint[1] = self.OrtsVektor[1] + self.DirectionVector[1] * self.factor


    def draw(self,screen):
        pg.draw.line(screen,BLACK,self.OrtsVektor, self.TheoreticalCollisionPoint)
        self.move()
        pg.draw.line(screen,WHITE,self.OrtsVektor, self.TheoreticalCollisionPoint)

# class Ray:
#    def __init__(self,pos,direction):
#        #Beginning Positions
#        self.Source = pos
#        self.direction = direction
#        # "Real" Positions of Lightray
#        self.x = 0
#        self.y = 0
#        self.xs = 0
#        self.ys = 0
#        self.End = (self.x, self.y)
#        # Default Rayfactor
#        self.factor = 1000
#        # List to compare RayIntersection lenghts
#        self.f_list = [1000]


#    def move(self):
#        #Always set the direction to the mouse position
#        #Set the x and y coordinate of the source to the middle and put them in direction tuple
#        self.xs = (pg.mouse.get_pos()[0] - self.Source[0])
#        self.ys = (pg.mouse.get_pos()[1] - self.Source[1])
#     #    self.direction = (self.xs, self.ys)


#    def draw(self, screen):
#        #Clear the previous by drawing black over it before updating End
#        ## For some fun comment this line
#        pg.draw.line(screen, BLACK, self.Source, self.End)
#        #Setting the x and y End of Ray Coordinates by mutipying the direction with the factor ( and adding the Half window cause of pygame)
#        self.x = self.direction[0] * self.factor + self.Source[0]
#        self.y = self.direction[1] * self.factor + self.Source[1]
#        #putting x and y in End tuple and draw the line on the screen
#        self.End = (self.x, self.y) 
#        pg.draw.line(screen, WHITE, self.Source, self.End)


class Boundary:
    def __init__(self, p1, p2):
        self.p1 = p1
        self.p2 = p2
        self.Boundary_Thickness = 3

    def draw(self, screen):
        pg.draw.line(screen, WHITE, self.p1, self.p2, self.Boundary_Thickness)