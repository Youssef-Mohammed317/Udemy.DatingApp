export type Member= {
  id: string;
  dateOfBirth: string; // ISO date string (e.g., "1986-07-22")
  imageUrl?: string;
  displayName: string;
  created: string; // ISO datetime string
  lastActive: string; // ISO datetime string
  gender: string;
  description?: string;
  city: string;
  country: string;
}
export type  Photo ={
  id: number;
  url: string;
  publicId?: string;
  memberId: string;
}