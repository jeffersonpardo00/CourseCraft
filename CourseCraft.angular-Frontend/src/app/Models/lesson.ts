export interface LessonGUI {
  lesson: LessonI;
  isOpen: boolean;
}

export interface LessonI{
  id: number;
  title: string;
  subject: string;
  lastAdjustement: Date;
  content: LessonContent;
}

export interface LessonContent {
  explanation: string;
  strategies: string;
}

export const defaultLessons: LessonGUI[] = [
    {
      lesson: {
        id: 1,
        title: 'Section 1',
        subject: '',
        lastAdjustement: new Date("1900-01-01"),
        content: {
          explanation:'No content provided',
          strategies:'No content provided'
        },
      },
      isOpen: false,
    }
  ];