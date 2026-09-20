export interface StudentCardView {
  name: string;
  age: number;
  level: number;
  photoUrl: string;
}

export const defaultstudent: StudentCardView = {
  name: 'Sara Martinez',
  age: 7,
  level: 2,
  photoUrl:
    'https://images.unsplash.com/photo-1524504388940-b1c1722653e1?auto=format&fit=crop&w=400&q=80',
};