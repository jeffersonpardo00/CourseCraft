export interface StudentResponse {
  FirstName: string;
  MiddleName: string;
  LastName: string;
  LastName2: string;
  Email: string;
  BirthDate: Date;
  LearningLevel: number;
  Interests: string[];
  Notes: string[];
}

export const defaultStudentResponse: StudentResponse = {
  FirstName: '',
  MiddleName: '',
  LastName: '',
  LastName2: '',
  Email: '',
  BirthDate: new Date('1900-01-01'),
  LearningLevel: -1,
  Interests: [],
  Notes: []
 };

export type StudentAIRequest = Omit<StudentResponse, 'Email'>;

export const defaultStudentAIRequest: StudentAIRequest = {
  FirstName: '',
  MiddleName: '',
  LastName: '',
  LastName2: '',
  BirthDate: new Date('1900-01-01'),
  LearningLevel: -1,
  Interests: [],
  Notes: []
 };

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

export const StudentResponseToAIRequest = 
    (studentResponse: StudentResponse): StudentAIRequest =>
      {
        const { Email, ...Resp } = studentResponse;
        return Resp as StudentAIRequest;
      }
